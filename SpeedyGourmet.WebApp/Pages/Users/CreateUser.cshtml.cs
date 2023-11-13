using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class CreateUser : PageModel
    {
        private readonly IUserService _userService;

        public CreateUser(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            User user = new User();
            user.UserName = Convert.ToString(Request.Form["username"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.IsAdmin = false;
            user.IsBlocked = false;

            _userService.Create(user);
            return RedirectToPage("/Users/GetAll");
        }
    }
}
