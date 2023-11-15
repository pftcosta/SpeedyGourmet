using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Login
{
    public class Login : PageModel
    {
        private readonly IUserService _userService;

        public Login(IUserService userService)
        {
            _userService = userService;
        }

        public User User { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            SetUser();
            return Redirect("/Index");
        }

        private void SetUser()
        {
            string username = Convert.ToString(Request.Form["username"]);
            string password = Convert.ToString(Request.Form["password"]);
            User u = _userService.LogIn(username, password);

            string jsonString = JsonSerializer.Serialize(u);

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
