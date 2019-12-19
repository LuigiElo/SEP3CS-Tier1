using System;

namespace SEP3.Models
{
    /// <summary>
    /// Contains the info for an invitation.
    ///
    /// </summary>
    [Serializable]
    public class Invitation
    {
        
        public int personId { get; set; }
        public Party party { get; set; }
        public string status { get; set; }
        
    }
}