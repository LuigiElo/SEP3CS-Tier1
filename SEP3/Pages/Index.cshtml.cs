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
        [BindProperty] public ViewModel viewModel { get; set; }

        public class ViewModel
        {
            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }
        }


        [BindProperty]
        [Required(ErrorMessage = "Please supply a Username")]
        public string Username { get; set; }





        public Person Login { get; set; }
        public Person Register { get; set; }
        public String Value = "I got this value from the index page";
        private InUserSingleton _userSingleton;


        public string Label { get; set; }

        private readonly ILogger<IndexModel> _logger;

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

            Console.WriteLine("I am heeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeereeeeeeeeeeeeeeeeeeee");

            if (ModelState.IsValid)
            {
                Console.WriteLine("now i am hereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
                if (person.name == null && person.email == null)
                {
                    Console.WriteLine(person.username);
                    Console.WriteLine(person.isHost);
//                    Task<Person> taskP = rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/login");
//                    Person person1 = taskP.Result;
                    Person person1 = person;
                    person1.personID = 1;
                    person1.isHost = false;
                    Userr user = new Userr();
                    user.isHost = person1.isHost.ToString();

                    var claims = new List<Claim>{
                        new Claim("Role",user.isHost.ToLower()),
                        
                        
                    };
                    


                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    
                    if(person1==null)
                    {
                        return Page();
                    }
                    else
                    {
                        _userSingleton.setUser(person1);
                        return RedirectToPage("UserPage", "SingleValue", new {personId = person1.personID});
                    }
                }
                else
                {

                    Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
                    rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/register");
                    return RedirectToPage("Index");
                }



//
//                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
//                {
//                    Console.WriteLine(error.ErrorMessage);
//                }


            }

            return Page();

        }
    }
}    
