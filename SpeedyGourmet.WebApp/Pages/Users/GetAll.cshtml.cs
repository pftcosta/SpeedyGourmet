using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class GetAll : PageModel
    {
        private readonly IUserService _userService;

        public GetAll (IUserService userService)
        {
            _userService = userService;
        }

        public List<User> users = new();

        public void OnGet()
        {
            users = _userService.GetAll();
        }

        public void OnPost()
        {
            User user = new User();
            user.UserName = Convert.ToString(Request.Form["username"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.IsAdmin = false;
            user.IsBlocked = false;

            _userService.Create(user);
            OnGet();
        }
    }
}
