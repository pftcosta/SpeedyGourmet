using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class RegisterUserModel : PageModel
    {
        private readonly IService<User, int> _userService;

        public RegisterUserModel(IService<User, int> userService)
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
            user.IsAdmin = Convert.ToBoolean(Request.Form["is_admin"]);
            user.IsBlocked = Convert.ToBoolean(Request.Form["is_blocked"]);

            _userService.Create(user);
            return RedirectToPage("/Users/GetAll");
        }
    }
}
