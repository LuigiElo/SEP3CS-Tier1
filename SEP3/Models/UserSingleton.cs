using System.Collections.Generic;

namespace SEP3.Models
{
    public sealed class UserSingleton : InUserSingleton
    {
        private static UserSingleton instance = null;
        private static readonly object padlock = new object();

        private static Person user;
        private static List<Party> parties;
        private static Party activeParty;
        
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
    }
}