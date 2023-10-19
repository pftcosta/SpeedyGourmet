using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class UpdateModel : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public UpdateModel(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public Ingredient ingredient = new();

        public void OnGet(int id)
        {
            ingredient = _ingredientService.GetById(id);
        }

        public IActionResult OnPost()
        {
            ingredient.Id = Convert.ToInt32(Request.Form["id"]);
            ingredient.Name = Convert.ToString(Request.Form["name"]);
            _ingredientService.Update(ingredient);
            return Redirect("/Ingredients/GetAll");
        }
    }
}
