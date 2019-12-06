using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3.Models;
using SEP3.Services;


namespace SEP3.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {
        private IUserService _userService;
        public UsersViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }
    }
}
