using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.LogIn
{
    public class Register : PageModel
    {
        private readonly IUserService _userService;

        public Register(IUserService userService, User user)
        {
            _userService = userService;
            User = user;
        }

        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
        }

        public IActionResult OnPost()
        {
            User.Name = Convert.ToString(Request.Form["name"]);
            User.UserName = Convert.ToString(Request.Form["username"]);
            User.Email = Convert.ToString(Request.Form["email"]);
            User.Password = Convert.ToString(Request.Form["password"]);
            User.IsAdmin = false;
            User.IsBlocked = false;

            _userService.Create(User);
            return RedirectToPage("/LogIn/LogIn");
        }

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
