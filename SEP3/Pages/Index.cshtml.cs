using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SEP3.Manager;
using SEP3.Models;
using Microsoft.AspNetCore.Mvc;


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
                    // Task<Person> taskP = rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/login");
                    // Person person1 = taskP.Result;
                    
                    Person person1 = new Person();
                    
                    if(person1==null)
                    {
                        return Page();
                    }
                    else
                    {
                        return RedirectToPage("UserPage", "SingleValue", new {personId = person1.personID});
                    }
                }



                Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
                    //rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/register");
                    return RedirectToPage("Index");
                }

                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }


                return Page();

                // return RedirectToPage("HomePage");
//            }
//            return Page();
            }
        }
    }
    
