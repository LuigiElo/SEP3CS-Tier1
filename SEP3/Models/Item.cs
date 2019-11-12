﻿﻿﻿﻿using System;

  namespace PartyPlanner.Models
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        
    }
}