﻿﻿﻿﻿using System;

    namespace SEP3.Models
{
    /// <summary>
    /// Contains the info for an item.
    /// </summary>
    [Serializable]
    public class Item
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        
        
    }
}