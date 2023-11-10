using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAllByRecipeModel : PageModel
    {
        private readonly IILPostService<IngredientLine, int> _iLService;
        private readonly IRecFavService<Recipe, int> _recipeService;

        public GetAllByRecipeModel(IILPostService<IngredientLine, int> iLService, IRecFavService<Recipe, int> recipeService)
        {
            _iLService = iLService;
            _recipeService = recipeService;
        }

        public List<IngredientLine> ingredientLines = new();
        public List<Ingredient> ingredients = new();
        public List<Measure> measures = new();
        public List<Recipe> recipes = new();

        public IngredientLine ingredientLine = new();
        public Recipe recipe = new();

        public void OnGet(int id)
        {
            ingredientLines = _iLService.GetAllByRecipeId(id);
            recipes = _recipeService.GetAll();
            ingredientLine.Recipe = _recipeService.GetById(id);
        }

        public void /*IActionResult*/ OnPost()
        {
            Recipe recipe = new();
            ingredientLine.Recipe = recipe;
            ingredientLine.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            OnGet(ingredientLine.Recipe.Id);
        }
    }
}
