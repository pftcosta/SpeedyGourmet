using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class Delete : PageModel
    {
        private readonly IUserService _userService;

        public Delete(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet(int userId)
        {
            _userService.Delete(userId);
            return Redirect("/Users/GetAll");
        }
    }
}
