using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAllByRecipe : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IRecipeService _recipeService;

        public GetAllByRecipe(IIngredientLineService ingredientLineService, IRecipeService recipeService, List<IngredientLine> ingredientLines, List<Recipe> recipes, IngredientLine ingredientLine, Recipe recipe)
        {
            _ingredientLineService = ingredientLineService;
            _recipeService = recipeService;
            IngredientLines = ingredientLines;
            Recipes = recipes;
            IngredientLine = ingredientLine;
            Recipe = recipe;
        }

        public List<IngredientLine> IngredientLines { get; set; }
        public List<Recipe> Recipes { get; set; }
        public IngredientLine IngredientLine { get; set; }
        public Recipe Recipe { get; set; }

        public void OnGet(int id)
        {
            IngredientLines = _ingredientLineService.GetAllByRecipeId(id);
            IngredientLine.Recipe = _recipeService.GetById(id);
        }

        public void OnPost()
        {
            IngredientLine.Recipe = Recipe;
            IngredientLine.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            OnGet(IngredientLine.Recipe.Id);
        }
    }
}
