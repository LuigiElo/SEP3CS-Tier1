using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SEP3.Manager;
using SEP3.Models;
using Microsoft.AspNetCore.Mvc;
using SEP3.Entities;


namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {
        //bind properties used for the login
        [BindProperty] public ViewModel viewModel { get; set; }

        public class ViewModel
        {
            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }
        }
        
        [BindProperty]
        [Required(ErrorMessage = "Please supply a Username")]
        public string Username { get; set; }
        private readonly ILogger<IndexModel> _logger;
                
        //Singleton used to populate the common application info on login
        private InUserSingleton _userSingleton;

        public IndexModel(ILogger<IndexModel> logger, InUserSingleton userSingleton)
        {
            _logger = logger;
            _userSingleton = userSingleton;
        }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            RequestManager rm = new RequestManager();
            Person person = new Person();
            person.password = viewModel.Password;
            person.username = Username;


            if (ModelState.IsValid)
            { 
                if (person.name == null && person.email == null)
                {
                    Console.WriteLine(person.username);
                    Console.WriteLine(person.isHost);
                    Task<Person> taskP = rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/login");
                    Person person1 = taskP.Result;
                    var claims = new List<Claim>
                    {
                        new Claim("Role", "false"),
                    };
                    


                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if (person1 == null)
                    {
                        return RedirectToPage("Error");
                    }
                    else
                    {
                        _userSingleton.setUser(person1); 
                        return RedirectToPage("UserPage", "SingleValue", new {personId = person1.personID});

                    }
                }
                
            }

            return Page();

        }
    }
}    
