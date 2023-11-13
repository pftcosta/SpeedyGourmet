using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetByIdModel : PageModel
    {
        private readonly IRecipeService<Recipe, int> _recipeService;
        private readonly IIIngredientLineService<IngredientLine, int> _ingredientLineService;

        public GetByIdModel(IRecipeService<Recipe, int> recipeService, IIIngredientLineService<IngredientLine, int> ingredientLineService)
        {
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
        }

        public Recipe Recipe { get; set; }

        public void OnGet(int id)
        {
            Recipe = _recipeService.GetById(id);
            Recipe.Ingredients = _ingredientLineService.GetAllByRecipeId(id);
        }
    }
}
