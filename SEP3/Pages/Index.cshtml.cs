using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Please supply a Name" )]  public string Name { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Password" )]  public string Password { get; set; }
        public string Username { get; set; }
        public object Login { get; set; }
        public object ConfPassword { get; set; }
        public object Email { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}