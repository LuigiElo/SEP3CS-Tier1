﻿﻿﻿﻿using System;

    namespace SEP3.Models
{
    /// <summary>
    /// This class contains all the data from the user.
    /// </summary>
    [Serializable]
    public class Person
    {
        public int personID { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public bool isHost { get; set; }

        public Person()
        {
            
        }


    }
}