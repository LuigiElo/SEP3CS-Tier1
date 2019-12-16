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


        // public List<Item> ItemsAdded = new List<Item>();
        // public List<Item> ItemsRemoved { get; set; }
        // public List<Person> PeopleAdded { get; set; }
        // public List<Person> PeopleRemoved { get; set; }


        public void addItem(Item item)
        {
            activeParty.items.Add(item);
        }


        public void addPerson(Person person)
        {
            activeParty.people.Add(person);
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
            if (_userSingleton.getActiveParty() != null)
            {
                activeParty = _userSingleton.getActiveParty().copy();
            }

            if (_userSingleton.getSearchResult() != null)
            {
                SearchedPeople = _userSingleton.getSearchResult();
            }
        }
        


        public RedirectToPageResult OnGetSetActiveParty(string partyTitle)
        {
            Console.WriteLine("I am in this method");
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
                    Console.WriteLine("I've changed the party");
                    Console.WriteLine(activeParty.partyTitle);
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

        public void OnPostSearchPerson(string smth)
        {
            RequestManager rm = new RequestManager();
            Console.WriteLine("olaaaa");
            Person p = new Person();
            Task<List<Person>> paTask = rm.GetSearch(p,
                "http://localhost:8080/Teir2_war_exploded/partyservice/searchPerson/" + SearchPerson);
            List<Person> people = paTask.Result;
            Console.WriteLine("olaaaa");
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
            

            Console.WriteLine("olaaaa");
            _userSingleton.setSearchResult(result);
            SearchedPeople = _userSingleton.getSearchResult();
            Console.WriteLine(_userSingleton.getSearchResult().Count);
        }


        public void OnPostAddPerson(string name)
        {
            Person p = new Person();
            Console.WriteLine("this is teh size of Searched people");
            Console.WriteLine(SearchedPeople.Count);
            for (int i = 0; i < SearchedPeople.Count; i++)
            {
                if (SearchedPeople[i].name.Equals(name))
                {
                    p = SearchedPeople[i];
                    Console.WriteLine("I have assigned the new person in the add");
                    //here it is the problem !!!!!!!!!!!!!!!!!!!!!!!! the search people is overwritten...idk why
                }
            }

            addPerson(p);
            _userSingleton.getPeopleAdded().Add(p);
            foreach (Person person1 in _userSingleton.getPeopleAdded())
            {
                Console.WriteLine(person1.name);
            }

            Console.WriteLine("I've added a person");
        }


        public void OnPostAddItem()
        {
            Console.WriteLine("I've added an item....not yet");
            Item item = Item;
            Console.WriteLine(Item.name);
            Console.WriteLine("the item is fine");
            addItem(item);
            _userSingleton.getItemsAdded().Add(item);
            foreach (Item item1 in _userSingleton.getItemsAdded())
            {
                Console.WriteLine(item1.name);
            }

            Console.WriteLine("I've added an item");
        }

        public RedirectToPageResult OnPostSaveParty()
        {
            Console.WriteLine("I am here motherfucker");
            Box box = new Box();
            box.party = activeParty;
            // box.itemsAdded = new List<Item>();
            box.itemsRemoved = new List<Item>();
            box.peopleAdded = _userSingleton.getPeopleAdded();
            box.peopleRemoved = new List<Person>();
            box.itemsAdded = _userSingleton.getItemsAdded();
            foreach (Item item1 in _userSingleton.getItemsAdded())
            {
                Console.WriteLine(item1.name);
            }
            foreach (Person person1 in _userSingleton.getPeopleAdded())
            {
                Console.WriteLine(person1.name);
            }
            //more things are pressumed to be added

            RequestManager rm = new RequestManager();

            Task<Party> parTask = rm.Post(box, "http://localhost:8080/Teir2_war_exploded/partyservice/updateParty");
            Party party = parTask.Result;

            if (party == null)
            {
                Console.WriteLine("The updated party is null");
                return RedirectToPage("Error");
            }
            else
            {
                for (int i = 0; i < _userSingleton.getParties().Count; i++)
                {
                    if (_userSingleton.getParties()[i].partyID.Equals(activeParty.partyID))
                    {
                        _userSingleton.getParties().RemoveAt(i);
                        Console.WriteLine("I removed the old party");
                    }
                }

                // Console.WriteLine(  _userSingleton.getParties().Remove(activeParty));
                activeParty = party.copy();
                _userSingleton.getParties().Add(party);
                _userSingleton.setActiveParties(party);
                _userSingleton.getItemsAdded().Clear();
                //more things to be clear
                return RedirectToPage("UserPage");
            }
        }
    }
}