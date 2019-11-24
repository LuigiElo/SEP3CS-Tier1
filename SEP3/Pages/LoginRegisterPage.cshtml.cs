using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SEP3.Pages
{
    public class LoginRegisterPage : PageModel
    {
        
        [BindProperty, Required(ErrorMessage = "Please supply a Name" )]  public string Name { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Password" )]  public string Password { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Please supply a Name" )]  public string Username { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Password" )]  public string ConfPassword { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Please supply a Name" )]  public string Login { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Password" )]  public string Email { get; set; }
        public void OnGet()
        {
            
        }
    }
}