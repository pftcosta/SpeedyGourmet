using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class Delete : PageModel
    {
        private readonly IService<Difficulty, int> _difficultyService;

        public Delete (IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public User User { get; set; }

        public IActionResult OnGet(int difficultyId)
        {
            GetUser();
            _difficultyService.Delete(difficultyId);
            return Redirect("/Difficulties/GetAll");
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
