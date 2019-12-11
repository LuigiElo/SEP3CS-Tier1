using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SEP3.Manager;
using SEP3.Models;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace SEP3.Pages
{
    public class UserPage : PageModel
    {
        public Person user;
        
        
        public Item Item { get; set; }
      
        public Party Party { get; set; }

        public List<Party> Parties { get; set; }
        public List<Item> Items { get; set; }
        public List<Person> Persons { get; set; }




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
            Console.WriteLine(personId +"!!!!!!!!!!!!!!!!!!!!!11");
            
            
            RequestManager rm = new RequestManager();
            Task<List<Party>> paTask = rm.Get(user,
                "http://localhost:8080/Teir2_war_exploded/partyservice/getPartiesForPerson/"+personId);
            List<Party> parties = paTask.Result;
            
//            List<Party> parties = new List<Party>();
//            List<Person> persons = new List<Person>();
//            List<Item> items = new List<Item>();
//            Person person1 = new Person();
//            
//            Party party1 = new Party();
//            Party party2 = new Party();
//            
//            Item item1 = new Item();
//
//            person1.name = "John";
//            item1.Name = "Cola";
//            
//            party1.partyTitle = "Something";
//            party2.partyTitle = "Else";
//            
//            parties.Add(party1);
//            parties.Add(party2);
//                
//            persons.Add(person1);
//            items.Add(item1);
//            
//            
//
//            Items = items;
//            Persons = persons;
//            
            


                Parties = parties;
              

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
                    Console.WriteLine(parties[i].partyTitle +" is one party!!!!!!!!!!!!!!!!!!!");
                }
            }

        }

        public PartialViewResult OnGetPartialItem(string id)
        {
            Console.WriteLine(id +  "is the value i got");
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