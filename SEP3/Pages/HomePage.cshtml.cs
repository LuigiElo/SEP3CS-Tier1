using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;

namespace SEP3.Pages
{
    [Authorize(Policy = "LoggedIn")]
    public class HomePage : PageModel
    {
        
        //Singleton and common service user information
        private InUserSingleton _userSingleton { get; set; }
        public Person user { get; set; }
        public List<Party> parties { get; set; }
        public Party activeParty { get; set; }

        public HomePage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
            parties = userSingleton.getParties();
            activeParty = userSingleton.getActiveParty();
        }
        
        public void OnGet()
        {
            
        }
    }
}