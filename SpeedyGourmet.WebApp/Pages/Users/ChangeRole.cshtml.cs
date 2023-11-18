using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class ChangeRoleModel : PageModel
    {
        private readonly IUserService _userService;

        public ChangeRoleModel(IUserService userService)
        {
            _userService = userService;
        }
        
        public IActionResult OnGet(int id)
        {
            User user = _userService.GetById(id);
            user.IsAdmin = !user.IsAdmin;
            _userService.Update(user);
            return RedirectToPage("/Users/GetAll");
        }
    }
}
