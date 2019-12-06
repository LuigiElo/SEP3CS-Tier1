using System;
using System.Collections.Generic;

namespace SEP3.Models
{
    
    [Serializable]
    public class Box
    {
        
        public Party Party { get; set; }
        
        public List<Item> Items { get; set; }
        
        public List<Person> People { get; set; }
        
    }
}