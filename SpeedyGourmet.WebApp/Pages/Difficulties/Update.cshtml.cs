using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Difficulties
{
    public class UpdateModel : PageModel
    {

        private readonly IService<Difficulty, int> _difficultyService;

        public UpdateModel(IService<Difficulty, int> difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public Difficulty difficulty = new();

        public void OnGet(int id)
        {
            difficulty = _difficultyService.GetById(id);
        }

        public IActionResult OnPost()
        {
            difficulty.Id = Convert.ToInt32(Request.Form["id"]);
            difficulty.Name = Request.Form["name"];
            _difficultyService.Update(difficulty);
            return Redirect("/Difficulties/GetAll");
        }
    }
}
