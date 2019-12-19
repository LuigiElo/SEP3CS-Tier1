using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages

{
    /// <summary>
    /// Class that manages RegisterPage where its possible to register as a user.
    /// </summary>
    [AllowAnonymous]
    public class RegisterPage : PageModel
    {
        
        //bind property used for registration
        [BindProperty] public ViewModel viewModel { get; set; }

        public class ViewModel
        {
            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirmation Password is required.")]
            [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
            public string ConfPassword { get; set; }
        }
        [BindProperty]
        [Required(ErrorMessage = "Please supply a Name")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a Username")]
        public string Username { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Please supply a Email")]
        [EmailAddress]
        public string Email { get; set; }
        

        
        //Singleton used to encapsulate application common user information
        private InUserSingleton _userSingleton { get; set; }

        public RegisterPage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
        }


        public void OnGet()
        {
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <returns>Login Page <c>Index.html</c></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            RequestManager rm = new RequestManager();
            Person person = new Person();
            person.name = Name;
            person.email = Email;

            person.password = viewModel.Password;
            person.username = Username;
            

            if (ModelState.IsValid)
            {
                Task<Person> perTask = rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/register");
                Person person1 = perTask.Result;
                if (person1 != null)
                {
                    _userSingleton.setUser(person1);
                    return RedirectToPage("Index");
                }
             
            }
            
           
            return Page();
        }
    }
}