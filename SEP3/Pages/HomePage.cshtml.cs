using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;

namespace SEP3.Pages
{
    [Authorize(Policy = "LoggedIn")]
    public class HomePage : PageModel
    {
       

        public List<Party> Parties { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}