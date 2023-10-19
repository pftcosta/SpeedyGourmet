using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class GetByIdModel : PageModel
    {
        private readonly IService<Difficulty, int> _difficultyService;

        public GetByIdModel(IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public Difficulty difficulty = new();

        public void OnGet(int id)
        {
            difficulty = _difficultyService.GetById(id);
        }
    }
}
