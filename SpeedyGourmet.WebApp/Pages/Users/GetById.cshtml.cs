using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class GetById : PageModel
    {
        private readonly IUserService _userService;

        public GetById(IUserService userService)
        {
            _userService = userService;
        }

        public User user = new();

        public void OnGet(int id)
        {
            user = _userService.GetById(id);
        }

        public IActionResult OnPost()
        {
            user.Id = Convert.ToInt32(Request.Form["id"]);
            user = _userService.GetById(user.Id);

            string newUserName = Convert.ToString(Request.Form["username"]);
            if (string.IsNullOrWhiteSpace(newUserName))
            {
                newUserName = "USER NAME NOT SET";
            }
            else if (newUserName != user.UserName)
            {
                user.UserName = newUserName;
            }

            string newPassword = Convert.ToString(Request.Form["password"]);
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                newPassword = "1234";
            }
            else if (newPassword != user.Password)
            {
                user.Password = newPassword;
            }

            string newName = Convert.ToString(Request.Form["name"]);
            if (string.IsNullOrWhiteSpace(newName))
            {
                newName = "NAME NOT SET";
            }
            else if (newName != user.Name)
            {
                user.Name = newName;
            }

            string newEmail = Convert.ToString(Request.Form["email"]);
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                newEmail = "EMAIL NOT SET";
            }
            else if (newEmail != user.Email)
            {
                user.Email = newEmail;
            }

            bool? newIsAdmin = null;
            if (bool.TryParse(Request.Form["is_admin"], out var isAdminValue))
            {
                newIsAdmin = isAdminValue;
            }

            if (newIsAdmin.HasValue)
            {
                user.IsAdmin = newIsAdmin.Value;
            }

            bool? newIsBlocked = null;
            if (bool.TryParse(Request.Form["is_blocked"], out var isBlockedValue))
            {
                newIsBlocked = isBlockedValue;
            }

            if (newIsBlocked.HasValue)
            {
                user.IsBlocked = newIsBlocked.Value;
            }

            _userService.Update(user);
            return Redirect("/Users/GetAll");
        }
    }
}