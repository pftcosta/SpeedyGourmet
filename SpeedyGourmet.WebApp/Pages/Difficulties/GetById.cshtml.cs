using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class GetById : PageModel
    {
        private readonly IService<Difficulty, int> _difficultyService;

        public GetById(IService<Difficulty, int> difficultyService)
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
