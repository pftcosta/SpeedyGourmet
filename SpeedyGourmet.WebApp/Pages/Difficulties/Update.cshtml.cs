using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class Update : PageModel
    {

        private readonly IService<Difficulty, int> _difficultyService;

        public Update (IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public Difficulty Difficulty { get; private set; }
        public User User { get; set; }

        public void OnGet(int difficultyId)
        {
            GetUser();
            Difficulty = _difficultyService.GetById(difficultyId);
        }

        public IActionResult OnPost()
        {
            Difficulty = new Difficulty()
            {
                Id = Convert.ToInt32(Request.Form["id"]),
                Name = Request.Form["name"]
            };

            _difficultyService.Update(Difficulty);
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
