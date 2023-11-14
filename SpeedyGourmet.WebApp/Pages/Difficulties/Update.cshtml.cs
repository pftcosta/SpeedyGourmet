using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

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

        public void OnGet(int id)
        {
            Difficulty = _difficultyService.GetById(id);
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
    }
}
