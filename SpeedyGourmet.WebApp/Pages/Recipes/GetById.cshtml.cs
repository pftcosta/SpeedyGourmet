using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetById : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientLineService _ingredientLineService;

        public GetById(IRecipeService recipeService, IIngredientLineService ingredientLineService, Recipe recipe)
        {
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
            Recipe = recipe;
        }

        public Recipe Recipe { get; set; }

        public void OnGet(int id)
        {
            Recipe = _recipeService.GetById(id);
            Recipe.Ingredients = _ingredientLineService.GetAllByRecipeId(id);
        }
    }
}
