using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    /// <summary>
    /// This class manages USerPartyPage which is the page for participants in a party
    /// </summary>
    [Authorize(Policy = "LoggedIn")]
    public class UserPartyPage : PageModel
    {
        //Singleton and common service user information
        private InUserSingleton _userSingleton { get; set; }
        public Person user { get; set; }
        public List<Party> parties { get; set; }

        public Party activeParty { get; set; }
        public Item Item { get; set; }
        
        public void addItem(Item item)
        {
            activeParty.items.Add(item);
        }


        public UserPartyPage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
            parties = userSingleton.getParties();
            if (userSingleton.getActiveParty() != null)
            {
                activeParty = userSingleton.getActiveParty().copy();
            }
        }
        public void OnGet()
        {
            
        }
        
        
        /// <summary>
        /// Sets the active party, based which one the user chose.
        /// </summary>
        /// <param name="partyTitle">Current Party title</param>
        /// <returns>Page depending on whether the user is a host for the party or not</returns>
        public RedirectToPageResult OnGetSetActiveParty(string partyTitle)
        {

            foreach (var party in parties)
            {
                if (party.partyTitle.Equals(partyTitle))
                {
                    activeParty = party.copy();
                    _userSingleton.setActiveParties(party);
                    _userSingleton.getItemsAdded().Clear();
                    _userSingleton.getPeopleAdded().Clear();
                    _userSingleton.getSearchResult().Clear();
                }
            }

            if (activeParty.host.name == _userSingleton.getUser().name)
            {
                return RedirectToPage("UserPage");
            }
            else
            {
                return RedirectToPage("UserPartyPage");
            }
        }
        
        /// <summary>
        /// Adds an item to the party
        /// </summary>
        public RedirectToPageResult OnPostAddItem()
        {
            
            Item item = Item;
            addItem(item);
            _userSingleton.getItemsAdded().Add(item);
            
            Box box = new Box();
            box.party = activeParty;
            box.itemsRemoved = new List<Item>();
            box.itemsAdded = _userSingleton.getItemsAdded();
            RequestManager rm = new RequestManager();
            Task<Party> parTask = rm.Post(box, "http://localhost:8080/Teir2_war_exploded/partyservice/updateParty");
            Party party = parTask.Result;
            if (party == null)
            {
                return RedirectToPage("Error");
            }
            else
            {
                for (int i = 0; i < _userSingleton.getParties().Count; i++)
                {
                    if (_userSingleton.getParties()[i].partyID.Equals(activeParty.partyID))
                    {
                        _userSingleton.getParties().RemoveAt(i);
                    }
                }

                activeParty = party.copy();
                _userSingleton.getParties().Add(party);
                _userSingleton.setActiveParties(party);
                _userSingleton.getItemsAdded().Clear();
                return RedirectToPage("UserPartyPage");
            }

        }
    }
}