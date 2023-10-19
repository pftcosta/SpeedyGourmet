using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class GetAllModel : PageModel
    {
        private readonly IService<Difficulty, int> _difficultyService;

        public GetAllModel(IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public List<Difficulty> difficulties = new();
        public void OnGet()
        {
            difficulties = _difficultyService.GetAll();
        }

        public void OnPost()
        {
            Difficulty difficulty = new();
            difficulty.Name = Convert.ToString(Request.Form["name"]);
            _difficultyService.Create(difficulty);
            OnGet();
        }
    }
}
