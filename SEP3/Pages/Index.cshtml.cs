﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please supply a Name")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Please supply a Password")]
        [DataType(DataType.Password)]

        public string Password2 { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a Username")]
        public string Username { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Please supply a Username")]
        public string Username2 { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a Password")]
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a Email")]
        public string Email { get; set; }


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
            RequestManager rm = new RequestManager();
            Person person = new Person();
            person.Name = Name;
            person.Email = Email;
            if (person.Name == null && person.Email == null)
            {
                person.Password = Password;
                person.Username = Username;
            }
            else
            {
                person.Password = Password2;
                person.Username = Username2;
            }
            

            Console.WriteLine(
                "I am heereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
//            if (ModelState.IsValid)
//            {
                Console.WriteLine("now i am hereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
                Console.WriteLine(Username2);
                if (person.Name == null && person.Email == null)
                {
                    rm.Post(person, "http://10.152.214.79:8080/Teir2_war_exploded/partyservice/login");
                    return RedirectToPage("UserPage");
                }

                Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
                rm.Post(person, "http://localhost:8080/Teir2_war_exploded/partyservice/register");
                return RedirectToPage("HomePage");
//            }
//            return Page();
        }
    }
}