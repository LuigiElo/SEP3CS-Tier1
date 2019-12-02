using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SEP3.Manager;
using SEP3.Models;
using Microsoft.AspNetCore.Mvc;


namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ViewModel viewModel { get; set; }
        public class ViewModel {
            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirmation Password is required.")]
            [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
            public string ConfPassword{ get; set; }
        }
        
        
        [BindProperty]
        [Required(ErrorMessage = "Please supply a Name")]
        public string Name { get; set; }
//
//        [BindProperty]
//        [Required(ErrorMessage = "Please supply a Password")]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//
//        public string Password { get; set; }
//
////        [BindProperty]
////        [Required(ErrorMessage = "Please supply a Password")]
////        [DataType(DataType.Password)]
////
////        public string Password2 { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a Username")]
        public string Username { get; set; }
//
////        [BindProperty]
////        [Required(ErrorMessage = "Please supply a Username")]
////        public string Username2 { get; set; }
//
//        [BindProperty]
//        [Required(ErrorMessage = "Please supply a Password")]
//        [DataType(DataType.Password)]
//        [CompareAttribute("Password", ErrorMessage = "Password and Confirmation Password must match.")]
//        public string ConfPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a Email")]
        public string Email { get; set; }


        public Person Login { get; set; }
        public Person Register { get; set; }


        public string Label { get; set; }

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
            RequestManager rm = new RequestManager();
            Person person = new Person();
            person.name = Name;
            person.email = Email;

            person.password = viewModel.Password;
            person.username = Username;

            Console.WriteLine("I am heeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeereeeeeeeeeeeeeeeeeeee");
            if (ModelState.IsValid)
            {
                Console.WriteLine("now i am hereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");

                if (person.name == null && person.email == null)
                {
                    rm.Post(person, "http://10.152.214.79:8080/Teir2_war_exploded/partyservice/login");
                    return RedirectToPage("UserPage");
                }

                Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
                rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/register");
                return RedirectToPage("UserPage");
            }

            foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }


            return Page();
        }
    }
    
}