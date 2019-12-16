using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Manager;
using SEP3.Models;

namespace SEP3.Pages
{
    [Authorize(Policy = "LoggedIn")]
    public class HomePage : PageModel
    {
        //Singleton and common service user information
        private InUserSingleton _userSingleton { get; set; }
        public Person user { get; set; }
        public List<Party> parties { get; set; }
        public Party activeParty { get; set; }

        public List<Invitation> _invitations { get; set; }

        public HomePage(InUserSingleton userSingleton)
        {
            _userSingleton = userSingleton;
            user = userSingleton.getUser();
            parties = userSingleton.getParties();
            if (userSingleton.getActiveParty() != null)
            {
                activeParty = userSingleton.getActiveParty().copy();
            }
        }

        public void OnGetSingleValue(int personId)
        {
            RequestManager rm = new RequestManager();

            Task<List<Party>> paTask = rm.Get(user,
                "http://localhost:8080/Teir2_war_exploded/partyservice/getPartiesForPerson/" + personId);
            try
            {
                List<Party> partiesT = paTask.Result;

                _userSingleton.setParties(partiesT);
                parties = partiesT;
                if (_userSingleton.getActiveParty() != null)
                {
                    activeParty = _userSingleton.getActiveParty().copy();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Task<List<Invitation>> inviTask = rm.GetInvites(user,
                "http://localhost:8080/Teir2_war_exploded/partyservice/getNotifications/" + personId);
            try
            {
                List<Invitation> invitations = inviTask.Result;
                _userSingleton.setInvitations(invitations);
                _invitations = _userSingleton.getInvitations();
                Console.WriteLine("hello! You got notifications!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public RedirectToPageResult OnGetSetActiveParty(string partyTitle)
        {
            Console.WriteLine("I am in this method");
            foreach (var party in parties)
            {
                if (party.partyTitle.Equals(partyTitle))
                {
                    activeParty = party.copy();
                    _userSingleton.setActiveParties(party);
                    _userSingleton.getItemsAdded().Clear();
                    //more should be cleared
                    Console.WriteLine("I've changed the party");
                    Console.WriteLine(activeParty.partyTitle);
                }
            }

            Console.WriteLine(activeParty.host.name);

            if (activeParty.host.name == _userSingleton.getUser().name)
            {
                return RedirectToPage("UserPage");
            }
            else
            {
                return RedirectToPage("UserPartyPage");
            }
        }

        public void OnGet()
        {
            RequestManager rm = new RequestManager();
            Task<List<Invitation>> inviTask = rm.GetInvites(user,
                "http://localhost:8080/Teir2_war_exploded/partyservice/getNotifications/" +
                _userSingleton.getUser().personID);
            try
            {
                List<Invitation> invitations = inviTask.Result;
                _invitations = invitations;
                Console.WriteLine("hello! You got notifications!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void OnPostAnswerInvite(int invite, string status)
        {
            RequestManager rm = new RequestManager();

            Console.WriteLine("I am in the answerInvite method");
            foreach (var invitation in _userSingleton.getInvitations())
            {
                if (invitation.party.partyID.Equals(invite))
                {
                    invitation.status = status;
                    Console.WriteLine("I've changed the status of this invite");
                    Task<String> response = rm.Post(invitation,
                        "http://localhost:8080/Teir2_war_exploded/partyservice/answerInvite");
                    String result = response.Result;

                    if (result.Equals("success"))
                    {
                        Console.WriteLine("Added to the party");
                    }
                    else
                    {
                        Console.WriteLine("something is fucked up");
                        RedirectToPage("Error");
                    }
                }
            }
        }
    }
}