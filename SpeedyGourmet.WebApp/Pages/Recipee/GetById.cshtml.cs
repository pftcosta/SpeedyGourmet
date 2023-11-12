using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetByIdModel : PageModel
    {
        private readonly IRecFavService<Recipe, int> _recipeService;
        private readonly IILPostService<IngredientLine, int> _ingredientLineService;

        public GetByIdModel(IRecFavService<Recipe, int> recipeService, IILPostService<IngredientLine, int> ingredientLineService)
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
