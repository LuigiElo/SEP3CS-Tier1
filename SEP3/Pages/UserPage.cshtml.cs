using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    public class UserPage : PageModel
    {
        public Person user;
        
        
        public Item Item { get; set; }
        public Party Party { get; set; }
        
        
        

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
            
            
//            RequestManager rm = new RequestManager();
//            Task<List<Party>> paTask = rm.Get(user,
//                "http://localhost:8080/Teir2_war_exploded/partyservice/getPartiesForPerson");
//            List<Party> parties = paTask.Result;
//
//            Console.WriteLine("AND I got his parties!!!!!!!!!!!!!!!!!!!!!!!");
//            if (parties == null)
//            {
//                Console.WriteLine("Right!...he doesn't have any");
//            }
//            else
//            {
//                for (int i = 0; i < parties.Count; i++)
//                {
//                    Console.WriteLine(parties[i].partyTitle +" is one party!!!!!!!!!!!!!!!!!!!");
//                }
//            }

        }
    }
}