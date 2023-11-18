using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class ChangeAcessModel : PageModel
    {
        private readonly IUserService _userService;

        public ChangeAcessModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet(int id)
        {
            User user = _userService.GetById(id);
            user.IsBlocked = !user.IsBlocked;
            _userService.Update(user);
            return RedirectToPage("/Users/GetAll");
        }
    }
}
