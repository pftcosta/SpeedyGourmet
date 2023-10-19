using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class DeleteModel : PageModel
    {
        private readonly IService<Difficulty, int> _difficultyService;

        public DeleteModel(IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public IActionResult OnGet(int id)
        {
            _difficultyService.Delete(id);
            return Redirect("/Difficulties/GetAll");
        }
    }
}
