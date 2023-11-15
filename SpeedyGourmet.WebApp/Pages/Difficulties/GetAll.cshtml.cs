using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class GetAll : PageModel
    {
        private readonly IService<Difficulty, int> _difficultyService;

        public GetAll (IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public List<Difficulty> Difficulties { get; private set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Difficulties = _difficultyService.GetAll();
        }

        public void OnPost()
        {
            string difficultyName = Convert.ToString(Request.Form["name"]);
            _difficultyService.Create(new Difficulty { Name = difficultyName });
            OnGet();
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
