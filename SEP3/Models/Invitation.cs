using System;

namespace SEP3.Models
{
    [Serializable]
    public class Invitation
    {
        public int personId { get; set; }
        public Party party { get; set; }
        public string status { get; set; }
        
    }
}