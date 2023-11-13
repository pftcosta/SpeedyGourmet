using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAll : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public GetAll(IIngredientLineService ingredientLineService, List<IngredientLine> ingredientLines, IngredientLine ingredientLine)
        {
            _ingredientLineService = ingredientLineService;
            IngredientLines = ingredientLines;
            IngredientLine = ingredientLine;
        }

        public List<IngredientLine> IngredientLines { get; set; }
        public IngredientLine IngredientLine { get; set; }

        public void OnGet()
        {
            IngredientLines = _ingredientLineService.GetAll();
        }

        public IActionResult OnPost()
        {
            IngredientLine.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            Ingredient ingredient = new();
            IngredientLine.Ingredient = ingredient;
            IngredientLine.Ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);

            Measure measure = new();
            IngredientLine.Measure = measure;
            IngredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            Recipe recipe = new();
            IngredientLine.Recipe = recipe;
            IngredientLine.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _ingredientLineService.Create(IngredientLine);

            return RedirectToPage("/IngredientLines/CreateRecipe", new { id = recipe.Id });
        }
    }
}
