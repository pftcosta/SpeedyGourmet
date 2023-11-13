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

        public User user = new();

        public IActionResult OnGet(int id)
        {
            _userService.Delete(id);
            return Redirect("/Users/GetAll");
        }
    }
}
