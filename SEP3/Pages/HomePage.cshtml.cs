using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;

namespace SEP3.Pages
{
    public class HomePage : PageModel
    {
        public List<Party> Parties { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}