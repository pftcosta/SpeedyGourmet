using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.LogIn
{
    public class Login : PageModel
    {
        public class LogInModel : PageModel
        {
            private readonly IUserService  _userService;

            public LogInModel(IUserService userService, User user)
            {
                _userService = userService;
                User = user;
            }

            public User User { get; set; }

            public void OnGet()
            {
            }

            public IActionResult OnPost()
            {
                SetUser();
                return RedirectToPage("/Index");

            }

            private void SetUser()
            {
                string username = Convert.ToString(Request.Form["username"]);
                string password = Convert.ToString(Request.Form["password"]);

                User = _userService.LogIn(username, password);
                
                string jsonString = JsonSerializer.Serialize(User);

                HttpContext.Session.SetString("user", jsonString);
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
}
