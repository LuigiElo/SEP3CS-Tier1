using System.Collections.Generic;
using SEP3.Manager;

namespace SEP3.Models
{
    /// <summary>
    /// Singleton class that allows the data flow between pages.
    /// It stores temporarily the user, invitation he has,
    /// the user participates and the changes made in a party until the moment you save it in the database.
    /// </summary>
    public sealed class UserSingleton : InUserSingleton
    {
        private static UserSingleton instance = null;
        private static readonly object padlock = new object();

        private static Person user;
        private static List<Party> parties;
        private static Party activeParty;

        private List<Item> itemsAdded = new List<Item>();
        private List<Item> itemsRemoved = new List<Item>();
        private List<Person> personsAdded = new List<Person>();
        private List<Person> personsRemoved = new List<Person>();
        
        
        private List<Person> searchResult = new List<Person>();

        private List<Invitation> invitations = new List<Invitation>();
        public static UserSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserSingleton();
                    }

                    return instance;
                }
            }
        }


        /// <summary>
        /// Sets the current user.
        /// </summary>
        /// <param name="person"></param>
        public static void setUser(Person person)
        {
            user = person;
        }

        /// <summary>
        /// Returns the current user.
        /// </summary>
        /// <returns>User</returns>
        public Person getUser()
        {
            return user;
        }

        /// <summary>
        /// Sets the parties.
        /// </summary>
        /// <param name="parties">List of Parties the user participates</param>
        public void setParties(List<Party> parties)
        {
            UserSingleton.parties = parties;
        }

        /// <summary>
        /// Returns all the parties.
        /// </summary>
        /// <returns>Parties user participates</returns>
        public List<Party> getParties()
        {
            return parties;
        }

        
        /// <summary>
        /// Sets the active party, the one being displayed on the page usually.
        /// </summary>
        /// <param name="party"></param>
        public void setActiveParties(Party party)
        {
            activeParty = party;
        }

        
        /// <summary>
        /// Returns the info for the active page.
        /// </summary>
        /// <returns>Active party object</returns>
        public Party getActiveParty()
        {
            return activeParty;
        }

        void InUserSingleton.setUser(Person person)
        {
            setUser(person);
        }


        /// <summary>
        /// Sets the items to be added to a party when saved.
        /// </summary>
        /// <param name="items">Items added to a party</param>
        public void setItemsAdded(List<Item> items)
        {
            itemsAdded = items;
        }

        /// <summary>
        /// Returns the items that were added to the party.
        /// </summary>
        /// <returns>List of Items added in the active party</returns>
        public List<Item> getItemsAdded()
        {
            return itemsAdded;
        }

        /// <summary>
        /// Sets items removed from the party
        /// </summary>
        /// <param name="items"></param>
        public void setItemsRemoved(List<Item> items)
        {
            itemsRemoved = items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Items removed from the party</returns>
        public List<Item> getItemsRemoved()
        {
            return itemsRemoved;
        }


        /// <summary>
        /// Set people added to the active party.
        /// </summary>
        /// <param name="persons"></param>
        public void setPeopleAdded(List<Person> persons)
        {
            personsAdded = persons;
        }
        
        /// <summary>
        /// Get people added to the active party.
        /// </summary>
        /// <returns></returns>
        public List<Person> getPeopleAdded()
        {
            return personsAdded;
        }

        /// <summary>
        /// Sets the people removed from the party.
        /// </summary>
        /// <param name="persons"></param>
        public void setPeopleRemoved(List<Person> persons)
        {
            personsRemoved = persons;
        }

        /// <summary>
        /// Get people removed from the active party.
        /// </summary>
        /// <returns></returns>
        public List<Person> getPeopleRemoved()
        {
            return personsRemoved;
        }

        /// <summary>
        /// Sets the result of the search for people for party.
        /// </summary>
        /// <param name="persons"></param>
        public void setSearchResult(List<Person> persons)
        {
            searchResult = persons;
        }

        /// <summary>
        /// Gets the result of the search for people.
        /// </summary>
        /// <returns></returns>
        public List<Person> getSearchResult()
        {
            return searchResult;
        }

        /// <summary>
        /// Sets the invitation for the parties.
        /// </summary>
        /// <param name="invitations"></param>
        public void setInvitations(List<Invitation> invitations)
        {
            this.invitations = invitations;
        }

        /// <summary>
        /// Gets all the invitation for the user.
        /// </summary>
        /// <returns></returns>
        public List<Invitation> getInvitations()
        {
            return invitations;
        }
    }
}