using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages{
    public class CreateParty : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Please supply a title")] public string PartyTitle { get; set; }
        [BindProperty, DataType("dd/mm/yyyy", ErrorMessage = "Please provide the date in format dd/mm/yyyy"),Required(ErrorMessage = "Please supply date" )] public string PartyDate { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a location" )]  public string PartyLocation { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a description" )]  public string PartyDescription { get; set; }
        
        public Party Party { get; set; }
        public Person[] People { get; set; }
        
        
        public void OnGet()
        {
            Console.WriteLine(33333333333);
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            Party = new Party();
            await Task.Delay(0);
            if (ModelState.IsValid)
            {
                Party.partyTitle = PartyTitle;
                Party.date = PartyDate;
                Party.location = PartyLocation;
                Party.description = PartyDescription;
                Console.WriteLine(Party.ToString());
                RequestManager rm = new RequestManager();
                rm.Post(Party,"http://localhost:8080/Teir2_war_exploded/partyservice/createparty");
                    
                return RedirectToPage("PartyCreated");
                    
            }

            return Page();
        }

        public void methodIWantTocallFromAnotherPage()
        {
            Console.WriteLine("I've modified this page from another page");
        }
    }
}