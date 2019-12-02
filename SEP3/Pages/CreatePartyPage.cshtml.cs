using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    public class CreatePartyPage : PageModel
    {
        
        [BindProperty]
        public bool IsPrivate { get; set; }

        [BindProperty]
        [ Required(ErrorMessage = "Please supply a title")] 
        public string Title { get; set; }
        
        
        [BindProperty]
        [ DataType(DataType.Date, ErrorMessage = "Please provide the date in format dd/mm/yyyy")]
        [Required(ErrorMessage = "Please supply date" )]
        public string Date { get; set; }
       
        
        [BindProperty]
        [ Required(ErrorMessage = "Please supply a location" )] 
        public string Location { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a description" )]  public string Description { get; set; }
        
        public Party Party { get; set; }
        public Person[] People { get; set; }
        
        [BindProperty]
        [ Required(ErrorMessage = "Please supply a time" )] 
        [DataType(DataType.Time)]
        public string Time { get; set; }


        public void OnGet()
        {
            
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            Party = new Party();
            await Task.Delay(0);
            if (ModelState.IsValid)
            {
                Party.partyTitle = Title;
                Party.date = Date;
                Party.location = Location;
                Party.description = Description;
                Party.time = Time;
                Console.WriteLine(Party.ToString());
                RequestManager rm = new RequestManager();
                rm.Post(Party,"http://localhost:8080/Teir2_war_exploded/partyservice/createparty");
                    
                return RedirectToPage("PartyCreated");
                    
            }

            return Page();
        }
    }
}