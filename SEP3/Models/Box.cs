using System;
using System.Collections.Generic;

namespace SEP3.Models
{
    
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