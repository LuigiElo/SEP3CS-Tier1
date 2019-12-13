using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Entities;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    [Authorize(Policy = "LoggedIn")]
    public class CreatePartyPage : PageModel
    {
        
        public CreatePartyPage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
            parties = userSingleton.getParties();
            activeParty = userSingleton.getActiveParty();

        }

        //Singleton and common service user information
        private InUserSingleton _userSingleton;
        public Person user { get; set; }
        public List<Party> parties { get; set; }
        public Party activeParty { get; set; }
        
        
        
        //html binded properties
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
        
        [BindProperty]
        [ Required(ErrorMessage = "Please supply a description" )] 
        public string Description { get; set; }
        
        [BindProperty]
        [ Required(ErrorMessage = "Please supply a time" )] 
        [DataType(DataType.Time)]
        public string Time { get; set; }
        
        
        //Object used to create the new party
        public Party Party { get; set; }
        
        [BindProperty]
        public String Playlist { get; set; }

        public void OnGet()
        {
            string s = HttpContext.User.Identity.IsAuthenticated+"";
            Console.WriteLine(s + "1111111111"  ) ;
            Console.WriteLine("4444444444444444");
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


               // Party.host = _userSingleton.getUser();
                Party.time = Time;
                Party.isPrivate = IsPrivate;
        
                var rm = new RequestManager();
                Task<Party> parTask = rm.Post(Party,"http://localhost:8080/Teir2_war_exploded/partyservice/createparty");
                Party = parTask.Result;
                if (Party !=null)
                {
                    _userSingleton.setActiveParties(Party);
                    _userSingleton.getParties().Add(Party);
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