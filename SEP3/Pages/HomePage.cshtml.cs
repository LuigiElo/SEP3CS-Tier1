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
    /// <summary>
    /// Class that manages the HomePAge where an user can see general info about parties and notifications
    /// </summary>
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

        /// <summary>
        /// Gets the info from the logged in user , so it can be displayed, such as invitations and parties.
        /// </summary>
        /// <param name="personId">Current user ID</param>
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the active party, based which one the user chose.
        /// </summary>
        /// <param name="partyTitle"></param>
        /// <returns>Page depending on whether the user is a host for the party or not</returns>
        public RedirectToPageResult OnGetSetActiveParty(string partyTitle)
        {
            foreach (var party in parties)
            {
                if (party.partyTitle.Equals(partyTitle))
                {
                    activeParty = party.copy();
                    _userSingleton.setActiveParties(party);
                    _userSingleton.getItemsAdded().Clear();
                    //more should be cleared
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Accepts or Denies an invite to a party.
        /// </summary>
        /// <param name="invite">Party ID</param>
        /// <param name="status">Accept or Deny</param>
        public void OnPostAnswerInvite(int invite, string status)
        {
            RequestManager rm = new RequestManager();

            foreach (var invitation in _userSingleton.getInvitations())
            {
                if (invitation.party.partyID.Equals(invite))
                {
                    invitation.status = status;
                    Task<Invitation> response = rm.Post(invitation,
                        "http://localhost:8080/Teir2_war_exploded/partyservice/answerInvite");
                    Invitation result = response.Result;

                    if (result != null)
                    {
                        if (status.Equals("accepted"))
                        {
                            _userSingleton.getParties().Add(invitation.party);
                        }
                    }
                    else
                    {
                        RedirectToPage("Error");
                    }

                }
            }
        }
    }
}