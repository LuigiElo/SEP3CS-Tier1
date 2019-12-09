﻿﻿﻿﻿using System;

    namespace SEP3.Models
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Person owner { get; set; }
        
        
    }
}