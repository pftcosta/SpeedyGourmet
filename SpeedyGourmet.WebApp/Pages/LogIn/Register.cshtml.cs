using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.LogIn
{
    public class RegisterModel : PageModel
    {
        private readonly IService<User, int> _userService;

        public RegisterModel(IService<User, int> userService)
        {
            _userService = userService;
        }

        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
        }

        public IActionResult OnPost()
        {
            User user = new User();
            user.Name = Convert.ToString(Request.Form["name"]);
            user.UserName = Convert.ToString(Request.Form["username"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.IsAdmin = false;
            user.IsBlocked = false;

            _userService.Create(user);
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
