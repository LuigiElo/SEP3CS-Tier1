using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace SEP3.Entities
{
   

        public class Userr : IdentityUser{
    
            [Key]
            public string Name { get; set; }
            [Required]
            public string Password { get; set; }
            
            
            public string personId { get; set; }
            
            public  string isHost { get; set; }

            public ICollection<MyClaim> Claims { get; set; }
        }
    
}