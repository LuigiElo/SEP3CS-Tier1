using System;
using System.Collections.Generic;

namespace SEP3.Models
{
    /// <summary>
    /// This class contains the changes made in a party that need to be change, so it is a package that then
    /// is used in the 2nd tier to update the party info according to the changes in the view.
    /// </summary>
    [Serializable]
    public class Box
    {
        
        public Party party { get; set; }
        
        
        public List<Item> itemsAdded { get; set; }
        public List<Item> itemsRemoved { get; set; }
        
        
        public List<Person> peopleAdded { get; set; }
        public List<Person> peopleRemoved { get; set; }
    }
}