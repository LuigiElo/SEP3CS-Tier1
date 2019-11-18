﻿﻿﻿﻿using System;
 using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PartyPlanner.Models
{
    [Serializable]
    public class Party
    {
        public Party(string partyTitle, string description, string location, string partyId)
        {
            this.partyTitle = partyTitle;
            this.description = description;
            this.location = location;
            this.partyID = partyId;
        }
//        public List<Person> Attendants { get; set; }
//        public List<Item> Items { get; set; }
//        public string Date { get; set; }

        public Party()
        {
            
        }

        public string partyTitle { get; set; }
        public string description { get; set; }
        public string location { get; set; }

        public string partyID { get; set; }
//
//        public void AddAttendant(Person person)
//        {
//            Attendants.Add(person);
//        }
//
//        public void AddAttendants(Person[] people)
//        {
//            foreach (Person person in people)
//            {
//                Attendants.Add(person);
//            }
//        }
//
//        public void RemoveAttendant(Person person)
//        {
//            Attendants.Remove(person);
//        }
//        
//        public void AddItem(Item item)
//        {
//            Items.Add(item);
//        }
//
//        public void RemoveItems(Item item)
//        {
//            Items.Remove(item);
//        }


        public override string ToString()
        {
            return partyTitle + ",  "  + ",  " + location + "/n" + description;
        }
    }
}