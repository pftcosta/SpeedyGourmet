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

        public GetById(IRecipeService recipeService, IIngredientLineService ingredientLineService)
        {
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
        }

        public Recipe Recipe { get; private set; }

        public void OnGet(int recipeId)
        {
            Recipe = _recipeService.GetById(recipeId);
            Recipe.Ingredients.AddRange(_ingredientLineService.GetAllByRecipeId(recipeId));
        }
    }
}
