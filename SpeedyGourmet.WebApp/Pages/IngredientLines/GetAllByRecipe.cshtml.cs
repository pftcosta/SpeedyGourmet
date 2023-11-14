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

        public GetAllByRecipe(IIngredientLineService ingredientLineService, IRecipeService recipeService)
        {
            _ingredientLineService = ingredientLineService;
            _recipeService = recipeService;
        }

        public List<IngredientLine> IngredientLines { get; private set; }
        public List<Recipe> Recipes { get; private set; }
        public IngredientLine IngredientLine { get; private set; }
        public Recipe Recipe { get; private set; }

        public void OnGet(int recipeId)
        {
            IngredientLines = _ingredientLineService.GetAllByRecipeId(recipeId);
            Recipe = _recipeService.GetById(recipeId);
        }

        public void OnPost()
        {
            int recipeId = Convert.ToInt32(Request.Form["id_recipe"]);
            OnGet(recipeId);
        }
    }
}
