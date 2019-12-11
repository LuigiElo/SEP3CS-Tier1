﻿﻿﻿﻿using System;

    namespace SEP3.Models
{
    [Serializable]
    public class Item
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        
        
    }
}