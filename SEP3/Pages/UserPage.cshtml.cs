using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;

namespace SEP3.Pages
{
    public class UserPage : PageModel
    {
        public Person user;
        
        public void OnGet()
        {
            user = new Person();
            user.name = "jhon";
            ViewData.Add("0",user);
        }
    }
}