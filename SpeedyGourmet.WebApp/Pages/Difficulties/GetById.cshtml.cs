using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

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

        public void OnGet(int difficultyId)
        {
            Difficulty = _difficultyService.GetById(difficultyId);
        }
    }
}
