using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using SEP3.Manager;
using SEP3.Models;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace SEP3.Pages
{
    /// <summary>
    /// This class manages the Host Page (UserPage) of the party
    /// </summary>
    [Authorize(Policy = "LoggedIn")]
    public class UserPage : PageModel
    {
        //Singleton and common service user information
        private InUserSingleton _userSingleton { get; set; }
        public Person user { get; set; }
        public List<Party> parties { get; set; }

        public Party activeParty { get; set; }


        public UserPage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
            parties = userSingleton.getParties();
            if (userSingleton.getActiveParty() != null)
            {
                activeParty = userSingleton.getActiveParty().copy();
            }

            if (_userSingleton.getSearchResult() != null)
            {
                SearchedPeople = _userSingleton.getSearchResult();
            }
        }

        // info of current Party showned
        public List<Item> Items { get; set; }
        public List<Person> Persons { get; set; }

        //objects used for the update of the party
        public Box box { get; set; }

        //idk
        [BindProperty] public Item Item { get; set; }

        public List<Person> SearchedPeople = new List<Person>();

        [BindProperty] public String SearchPerson { get; set; }


        /// <summary>
        /// Adds item to active party
        /// </summary>
        /// <param name="item">Item wanted</param>
        public void addItem(Item item)
        {
            activeParty.items.Add(item);
        }


        /// <summary>
        /// Adds people to active party
        /// </summary>
        /// <param name="person"></param>
        public void addPerson(Person person)
        {
            activeParty.people.Add(person);
        }


        public void OnGet()
        {
        }

        
        /// <summary>
        /// Gets all the info needed for the page
        /// </summary>
        /// <param name="personId">User ID</param>
        public void OnGetSingleValue(int personId)
        {
            RequestManager rm = new RequestManager();

            Task<List<Party>> paTask = rm.Get(user,
                "http://localhost:8080/Teir2_war_exploded/partyservice/getPartiesForPerson/" + personId);
            List<Party> partiesT = paTask.Result;

            _userSingleton.setParties(partiesT);
            parties = partiesT;
            if (_userSingleton.getActiveParty() != null)
            {
                activeParty = _userSingleton.getActiveParty().copy();
            }

            if (_userSingleton.getSearchResult() != null)
            {
                SearchedPeople = _userSingleton.getSearchResult();
            }
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
                    //more should be cleared
                    
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
        /// Searches for a person and displays it.
        /// </summary>
        /// <param name="smth"> Input to be searched</param>
        public void OnPostSearchPerson(string smth)
        {
            RequestManager rm = new RequestManager();
            Person p = new Person();
            Task<List<Person>> paTask = rm.GetSearch(p,
                "http://localhost:8080/Teir2_war_exploded/partyservice/searchPerson/" + SearchPerson);
            List<Person> people = paTask.Result;
            List<Person> result = new List<Person>();
            if (people != null)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i] != null)
                    {
                        result.Add(people[i]);
                    }
                }
            }
            

            _userSingleton.setSearchResult(result);
            SearchedPeople = _userSingleton.getSearchResult();
        }


        /// <summary>
        /// Adds a person to the singleton until party is saved
        /// </summary>
        /// <param name="name"></param>
        public void OnPostAddPerson(string name)
        {
            Person p = new Person();
            for (int i = 0; i < SearchedPeople.Count; i++)
            {
                if (SearchedPeople[i].name.Equals(name))
                {
                    p = SearchedPeople[i];
                }
            }

            addPerson(p);
            _userSingleton.getPeopleAdded().Add(p);
            
        }


        /// <summary>
        /// Adds an item to the singleton until party is saved
        /// </summary>
        public void OnPostAddItem()
        {
            Item item = Item;
            addItem(item);
            _userSingleton.getItemsAdded().Add(item);

        }

        
        /// <summary>
        /// SAves the party with all the different changes made 
        /// </summary>
        /// <returns>UserPage</returns>
        public RedirectToPageResult OnPostSaveParty()
        {
            Box box = new Box();
            box.party = activeParty;
            box.itemsRemoved = new List<Item>();
            box.peopleAdded = _userSingleton.getPeopleAdded();
            box.peopleRemoved = new List<Person>();
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
                return RedirectToPage("UserPage");
            }
        }
    }
}