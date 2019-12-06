using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SEP3.Models
{
    public class LoginPage : PageModel
    {
        //get data from database:
       /* private UserContext context;

        public LoginPage(UserContext context)
        {
            this.context = context;
        } */

        //defining the Class, which contains the GUI input:
        public class InputModel
        {
            [Required] public string Name { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
        //binding the variable to View

        [BindProperty] public InputModel Input { get; set; }

       // public async Task OnGetAsync()
        //{
        //}
        
       // public async Task<ActivationResult> OnPostLoginAsync()
        
        
        







    }

    
}