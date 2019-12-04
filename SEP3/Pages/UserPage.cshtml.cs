using Microsoft.AspNetCore.Mvc.RazorPages;
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
    }
}