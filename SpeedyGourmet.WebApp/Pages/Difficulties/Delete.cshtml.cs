using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class Delete : PageModel
    {
        private readonly IService<Difficulty, int> _difficultyService;

        public Delete (IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public IActionResult OnGet(int difficultyId)
        {
            _difficultyService.Delete(difficultyId);
            return Redirect("/Difficulties/GetAll");
        }
    }
}
