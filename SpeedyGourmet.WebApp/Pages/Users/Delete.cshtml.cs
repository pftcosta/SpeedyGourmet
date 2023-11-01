using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IService<User, int> _userService;

        public DeleteModel(IService<User, int> userService)
        {
            _userService = userService;
        }

        public User user = new();

        public IActionResult OnGet(int id)
        {
            _userService.Delete(id);
            return Redirect("/Users/GetAll");
        }
    }
}
