using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class GetById : PageModel
    {
        private readonly IUserService _userService;

        public GetById(IUserService userService)
        {
            _userService = userService;
        }

        public User User { get; set; }
        public User UserEdit { get; private set; }

        public void OnGet(int userId)
        {
            GetUser();
            UserEdit = _userService.GetById(userId);
        }

        public IActionResult OnPost()
        {
            User = _userService.GetById(Convert.ToInt32(Request.Form["id"]));

            string newUserName = Convert.ToString(Request.Form["username"]);
            if (string.IsNullOrWhiteSpace(newUserName))
            {
                newUserName = "USER NAME NOT SET";
            }
            else if (newUserName != User.UserName)
            {
                User.UserName = newUserName;
            }

            string newPassword = Convert.ToString(Request.Form["password"]);
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                newPassword = "1234";
            }
            else if (newPassword != User.Password)
            {
                User.Password = newPassword;
            }

            string newName = Convert.ToString(Request.Form["name"]);
            if (string.IsNullOrWhiteSpace(newName))
            {
                newName = "NAME NOT SET";
            }
            else if (newName != User.Name)
            {
                User.Name = newName;
            }

            string newEmail = Convert.ToString(Request.Form["email"]);
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                newEmail = "EMAIL NOT SET";
            }
            else if (newEmail != User.Email)
            {
                User.Email = newEmail;
            }

            bool? newIsAdmin = null;
            if (bool.TryParse(Request.Form["is_admin"], out bool isAdminValue))
            {
                newIsAdmin = isAdminValue;
            }

            if (newIsAdmin.HasValue)
            {
                User.IsAdmin = newIsAdmin.Value;
            }

            bool? newIsBlocked = null;
            if (bool.TryParse(Request.Form["is_blocked"], out bool isBlockedValue))
            {
                newIsBlocked = isBlockedValue;
            }

            if (newIsBlocked.HasValue)
            {
                User.IsBlocked = newIsBlocked.Value;
            }

            _userService.Update(User);
            return Redirect("/Users/GetAll");
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