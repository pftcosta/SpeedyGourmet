using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class Update : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public Update(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public Ingredient Ingredient { get; private set; }

        public void OnGet(int ingredientId)
        {
            Ingredient = _ingredientService.GetById(ingredientId);
        }

        public IActionResult OnPost()
        {
            Ingredient = new Ingredient()
            {
                Id = Convert.ToInt32(Request.Form["id"]),
                Name = Convert.ToString(Request.Form["name"])
            };
            
            _ingredientService.Update(Ingredient);
            return Redirect("/Ingredients/GetAll");
        }
    }
}
