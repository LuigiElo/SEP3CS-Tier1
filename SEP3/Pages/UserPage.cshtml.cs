using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    [Authorize(Policy = "LoggedIn")]
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
           // Task<List<Party>> paTask = rm.Get(user,
           //     "http://localhost:8080/Teir2_war_exploded/partyservice/getPartiesForPerson/"+personId);
           // List<Party> parties = paTask.Result;
           Party p = new Party();
           p.partyTitle = "this one sucks";
           
           List<Party> parties = new List<Party>();
           parties.Add(p);
           parties.Add(p);
           
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
                    Console.WriteLine(parties[i].partyTitle +" is one party!!!!!!!!!!!!!!!!!!!");
                }
            }

        }
    }
}