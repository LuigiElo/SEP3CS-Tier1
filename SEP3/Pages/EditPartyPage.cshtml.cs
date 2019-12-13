using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    [Authorize(Policy = "LoggedIn")]
    public class EditPartyPage : PageModel
    {

      
        public EditPartyPage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
            parties = userSingleton.getParties();
            activeParty = userSingleton.getActiveParty();
            // _userSingleton.setActiveParties(activeParty);
        }

        //Singleton and common service user information
        private InUserSingleton _userSingleton;
        public Person user { get; set; }
        public List<Party> parties { get; set; }
        public Party activeParty { get; set; }
        
        
        
        //html binded properties
        [BindProperty] public bool IsPrivate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a title")]
        public string Title { get; set; }

        [BindProperty]
        [DataType(DataType.Date, ErrorMessage = "Please provide the date in format dd/mm/yyyy")]
        [Required(ErrorMessage = "Please supply date")]
        public string Date { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a location")]
        public string Location { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a description")]
        public string Description { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a time")]
        [DataType(DataType.Time)]
        public string Time { get; set; }
        
        //Object used to create the party with the new edits made
        public Party Party { get; set; }


        public void OnGet()
        {
            Title = activeParty.partyTitle;
            Description = activeParty.description;
            Location = activeParty.location;
            Time = activeParty.time;
            Date = activeParty.date;
            IsPrivate = activeParty.isPrivate;
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
                string isPrivate = Request.Form["sel1"];
                
                //not working as intended
                if (isPrivate.Equals("true"))
                    Party.isPrivate = true;
                else
                    Party.isPrivate = false;


         
                Party.time = Time;
                Party.isPrivate = IsPrivate;
                Party.partyID = activeParty.partyID;
            
                var rm = new RequestManager();
                Task<Party> partyTask = rm.Post(Party, "http://localhost:8080/Teir2_war_exploded/partyservice/updatePartyD");
                Party party = partyTask.Result;
                
               
                if (party != null)
                {
                    _userSingleton.getParties().Remove(activeParty);
                    _userSingleton.getParties().Add(party);
                    _userSingleton.setActiveParties(party);
                    activeParty = party;
                    
                    return RedirectToPage("UserPage");
                }
                else
                {
                    return RedirectToPage("Error");
                }
             

            }

            return Page();
        }
    }
}
