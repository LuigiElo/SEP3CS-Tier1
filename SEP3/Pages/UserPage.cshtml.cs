using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SEP3.Manager;
using SEP3.Models;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace SEP3.Pages
{
    [Authorize(Policy = "LoggedIn")]
    public class UserPage : PageModel
    {
        public Person user;
        private InUserSingleton _userSingleton;


        public UserPage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
        }

        public Item Item { get; set; }

        public Party Party { get; set; }

        public List<Party> Parties { get; set; }


        public List<Item> Items { get; set; }

        public List<Person> Persons { get; set; }
        public Person SearchPerson { get; set; }
       
        public void addItem()
        {
            // party.Items.add(Item);
        }


        public void addPerson()
        {
            // party.Persons.add(Person);
        }


        public void OnGet()
        {
//            {
//                user = new Person();
//                user.name = "jhon";
//                ViewData.Add("0",user);
//            }
        }

        public void OnGetSingleValue(int personId)
        {
            Console.WriteLine("I got my user");
            Console.WriteLine(personId + "!!!!!!!!!!!!!!!!!!!!!11");
            //user.personID = personId;
            RequestManager rm = new RequestManager();
            Task<List<Party>> paTask = rm.Get(user,
                "http://localhost:8080/Teir2_war_exploded/partyservice/getPartiesForPerson/" + personId);
            List<Party> parties = paTask.Result;


            Parties = parties;
            _userSingleton.setParties(parties);


            Console.WriteLine("AND I got his parties!!!!!!!!!!!!!!!!!!!!!!!");
            if (parties == null)
            {
                Console.WriteLine("Right!...he doesn't have any");
            }
            else
            {
                for (int i = 0; i < parties.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine(parties[0].toString());
                        Console.WriteLine("Items");
                        foreach (var item in parties[0].items)
                        {
                            Console.WriteLine(item.name);
                        }

                        Console.WriteLine("People");
                        foreach (var person in parties[0].people)
                        {
                            Console.WriteLine(person.name);
                        }
                    }

                    Console.WriteLine(parties[i].partyTitle + " is one party!!!!!!!!!!!!!!!!!!!");
                }
            }

        }

        public PartialViewResult OnGetPartialItem(string id)
        {
            Console.WriteLine(id + "is the value i got");
            foreach (var party in Parties)
            {
                if (party.partyTitle.Equals(id))
                {
                    Console.WriteLine("This is now the party");
                    Party = party;
                }
            }

            Party = Parties[0];
            Console.WriteLine("There is no current party");
            Items = Party.items;
            return Partial("_PartialItems", Items);
        }






    }
}