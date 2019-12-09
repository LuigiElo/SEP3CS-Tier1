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
    [AllowAnonymous]
    public class RegisterPage : PageModel
    {
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

        public object Register { get; set; }


        public void OnGet()
        {
            Console.WriteLine("222222222222222222");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RequestManager rm = new RequestManager();
            Person person = new Person();
            person.name = Name;
            person.email = Email;

            person.password = viewModel.Password;
            person.username = Username;

            Console.WriteLine("I am heeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeereeeeeeeeeeeeeeeeeeee");

            if (ModelState.IsValid)
            {

                Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
                rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/register");
                return RedirectToPage("Index");
            }

            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }


            return Page();
        }
    }
}