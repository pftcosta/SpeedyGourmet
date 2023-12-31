using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class CreateUser : PageModel
    {
        private readonly IUserService _userService;

        public CreateUser(IUserService userService)
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
            User user = new User()
            {
                UserName = Convert.ToString(Request.Form["username"]),
                Password = Convert.ToString(Request.Form["password"]),
                Name = Convert.ToString(Request.Form["name"]),
                Email = Convert.ToString(Request.Form["email"]),
                IsAdmin = false,
                IsBlocked = false
            };

            _userService.Create(user);
            return RedirectToPage("/Users/GetAll");
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
