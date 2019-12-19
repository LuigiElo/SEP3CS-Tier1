﻿﻿﻿﻿using System;
 using System.Collections.Generic;
using System.Runtime.Serialization;
    using SEP3.Manager;

    namespace SEP3.Models
{
    /// <summary>
    /// This class contains all the info of the party.
    /// </summary>
    [Serializable]
    public class Party
    {
        
  
        public int partyID { get; set; }
        public string partyTitle { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        
        public string date { get; set; }
        
        public string time { get; set; }
        
        public bool  isPrivate { get; set; }
        
        public String playlistURL { get; set; }
        
        
        public List<Person> people { get; set; }
        public List<Item> items { get; set; }
        
        public Person host { get; set; }

        public Party()
        {
            
        }
        

        /// <summary>
        /// Prints all thee info about the Party , mainly used in debugging and testing.
        /// </summary>
        /// <returns>String with the info</returns>
        public String toString() {
            return "Party{" +
                   "partyID='" + partyID + '\'' +
                   ", partyTitle='" + partyTitle + '\'' +
                   ", location='" + location + '\'' +
                   ", description='" + description + '\'' +
                   ", date='" + date + '\'' +
                   ", time='" + time + '\'' +
                   ", isPrivate='" + isPrivate +'\''+
                   ", items=" + items +
                   ", people=" + people +
                   '}';
        }


        /// <summary>
        /// Provides a copy of the party object.
        /// </summary>
        /// <returns>Party object clone</returns>
        public Party copy()
        {
            Party copy = new Party();
            copy.date = this.date;
            copy.description = this.description;
            copy.host = this.host;
            copy.items = this.items;
            copy.location = this.location;
            copy.people = this.people;
            copy.time = this.time;
            copy.isPrivate = this.isPrivate;
            copy.partyTitle = this.partyTitle;
            copy.partyID = this.partyID;
            copy.playlistURL = this.playlistURL;

            return copy;
        }
    }
}