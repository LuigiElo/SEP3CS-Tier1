using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    public class EditPartyPage : PageModel
    {

        private InUserSingleton _userSingleton;

        public EditPartyPage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
            parties = userSingleton.getParties();
            activeParty = parties[0];
        }

        public Person user { get; set; }
        public List<Party> parties { get; set; }
        public Party activeParty { get; set; }

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

        public Party Party { get; set; }
        public Person[] People { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please supply a time")]
        [DataType(DataType.Time)]
        public string Time { get; set; }

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
                Console.WriteLine(Party.isPrivate);
                //not working as intended
                if (isPrivate.Equals("true"))
                    Party.isPrivate = true;
                else
                    Party.isPrivate = false;


                Console.WriteLine(Party.isPrivate);
                Party.time = Time;
                Party.isPrivate = IsPrivate;
                Console.WriteLine(Party.isPrivate);
                Console.WriteLine(Party.date);
                Console.WriteLine(Party.time);
                var rm = new RequestManager();
                Task<Party> partyTask = rm.Post(Party, "http://localhost:8080/Teir2_war_exploded/partyservice/updatePartyD");
                Party party = partyTask.Result;
                if (party != null)
                {
                    Console.WriteLine("I got a party back! YEYYYY");
                }
                return RedirectToPage("UserPage");

            }

            return Page();
        }
    }
}
