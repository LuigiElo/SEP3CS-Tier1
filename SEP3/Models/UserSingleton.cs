using System.Collections.Generic;
using SEP3.Manager;

namespace SEP3.Models
{
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


        public static void setUser(Person person)
        {
            user = person;
        }

        public Person getUser()
        {
            return user;
        }

        public void setParties(List<Party> parties)
        {
            UserSingleton.parties = parties;
        }

        public List<Party> getParties()
        {
            return parties;
        }

        public void setActiveParties(Party party)
        {
            activeParty = party;
        }

        public Party getActiveParty()
        {
            return activeParty;
        }

        void InUserSingleton.setUser(Person person)
        {
            setUser(person);
        }


        public void setItemsAdded(List<Item> items)
        {
            itemsAdded = items;
        }

        public List<Item> getItemsAdded()
        {
            return itemsAdded;
        }

        public void setItemsRemoved(List<Item> items)
        {
            itemsRemoved = items;
        }

        public List<Item> getItemsRemoved()
        {
            return itemsRemoved;
        }


        public void setPeopleAdded(List<Person> persons)
        {
            personsAdded = persons;
        }

        public List<Person> getPeopleAdded()
        {
            return personsAdded;
        }

        public void setPeopleRemoved(List<Person> persons)
        {
            personsRemoved = persons;
        }

        public List<Person> getPeopleRemoved()
        {
            return personsRemoved;
        }

        public void setSearchResult(List<Person> persons)
        {
            searchResult = persons;
        }

        public List<Person> getSearchResult()
        {
            return searchResult;
        }

        public void setInvitations(List<Invitation> invitations)
        {
            this.invitations = invitations;
        }

        public List<Invitation> getInvitations()
        {
            return invitations;
        }
    }
}