﻿﻿﻿﻿using System;
 using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SEP3.Models
{
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
        
        
        public List<Person> people { get; set; }
        public List<Item> items { get; set; }

        public Party()
        {
            
        }
        

        
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
    }
}