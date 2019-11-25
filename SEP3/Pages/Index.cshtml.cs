using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SEP3.Models;

namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Please supply a Name" )]  public string Name { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Password" )]  public string Password { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Username" )] public string Username { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Please supply a Password" )] public string ConfPassword { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Email" )]public string Email { get; set; }
        
        public Person Login { get; set; }
        public Person Register { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            await Task.Delay(0);
            Console.WriteLine(Username);
            return RedirectToPage("CreatedParty");
        }
    }
}