using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAll : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public GetAll(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public List<IngredientLine> IngredientLines { get; private set; }

        public void OnGet()
        {
            IngredientLines = _ingredientLineService.GetAll();
        }

        public IActionResult OnPost()
        {
            IngredientLine ingredientLine = new IngredientLine
            {
                Quantity = Convert.ToInt32(Request.Form["quantity"]),
                Ingredient = new Ingredient { Id = Convert.ToInt32(Request.Form["id_ingredient"]) },
                Measure = new Measure { Id = Convert.ToInt32(Request.Form["id_measure"]) },
                Recipe = new Recipe { Id = Convert.ToInt32(Request.Form["id_recipe"]) }
            };

            _ingredientLineService.Create(ingredientLine);
            return RedirectToPage("/IngredientLines/CreateByRecipe", new { id = ingredientLine.Recipe.Id });
        }
    }
}
