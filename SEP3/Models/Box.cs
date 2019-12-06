using System;
using System.Collections.Generic;

namespace SEP3.Models
{
    
    [Serializable]
    public class Box
    {
        
        public Party Party { get; set; }
        
        
        public List<Item> ItemsAdded { get; set; }
        public List<Item> ItemsRemoved { get; set; }
        
        
        public List<Person> PeopleAdded { get; set; }
        public List<Person> PeopleRemoved { get; set; }
    }
}