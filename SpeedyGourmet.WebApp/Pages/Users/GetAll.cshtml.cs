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

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _userService.GetAll();
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
    }
}
