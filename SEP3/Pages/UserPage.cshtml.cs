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
    [AllowAnonymous]

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
            activeParty = userSingleton.getActiveParty();
            // if (activeParty != null)
            // {
            //     Items = activeParty.items;
            //     Persons = activeParty.people;
            // }
            // activeParty = userSingleton.getParties()[0];

        }
        
        // info of current Party showned
        public List<Item> Items { get; set; }
        public List<Person> Persons { get; set; }
        
        //objects used for the update of the party
        public Box box { get; set; }

        //idk
        [BindProperty] 
        public Item Item { get; set; }
        public  Person SearchPerson { get; set; }
        

        public void addItem(Item item)
        {
           activeParty.items.Add(item);
        }


        public void addPerson()
        {
         
        }


        public void OnGet()
        {
        }

        public void OnGetSingleValue(int personId)
        {
            RequestManager rm = new RequestManager();
            
            Task<List<Party>> paTask = rm.Get(user,
                "http://localhost:8080/Teir2_war_exploded/partyservice/getPartiesForPerson/" + personId);
            List<Party> partiesT = paTask.Result;
            
            _userSingleton.setParties(partiesT);
            parties = partiesT;
            activeParty = _userSingleton.getActiveParty();


        }

        public PartialViewResult OnGetPartialItem(string id)
        {
            Console.WriteLine(id + "is the value i got");
            foreach (var party in parties)
            {
                if (party.partyTitle.Equals(id))
                {
                    Console.WriteLine("This is now the party");
                    activeParty = party;
                    _userSingleton.setActiveParties(party);
                }
            }
            Console.WriteLine("There is no current party");
            Items = activeParty.items;
            return Partial("_PartialItems", Items);
        }



        public RedirectToPageResult OnGetSetActiveParty(string partyTitle)
        {
            Console.WriteLine("I am in this method");
            foreach (var party in parties)
            {
                if (party.partyTitle.Equals(partyTitle))
                {
                    activeParty = party;
                    _userSingleton.setActiveParties(party);
                    Console.WriteLine("I've changed the party");
                    Console.WriteLine(activeParty.partyTitle);
                }
            }

            return RedirectToPage("UserPage");
        }


        public void OnPostAddItem()
        {
            Console.WriteLine("I've added an item....not yet");
            Item item = Item;
            Console.WriteLine(Item.name);
            Console.WriteLine("the item is fine");
            addItem(item);
            Console.WriteLine("I've added an item");
            
        }

    }
}