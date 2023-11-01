using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Users
{
    public class GetByIdModel : PageModel
    {
        private readonly IService<User, int> _userService;

        public GetByIdModel(IService<User, int> userService)
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
            User user = new User();
            user.UserName = Convert.ToString(Request.Form["username"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Email = Convert.ToString(Request.Form["email"]);

            _userService.Update(user);
            return Redirect("/Users/GetAll");
        }
    }
}
