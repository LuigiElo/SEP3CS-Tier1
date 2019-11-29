﻿﻿﻿﻿using System;

    namespace SEP3.Models
{
    [Serializable]
    public class Person
    {
        public int personID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool isHost { get; set; }

        public Person()
        {
            
        }


    }
}