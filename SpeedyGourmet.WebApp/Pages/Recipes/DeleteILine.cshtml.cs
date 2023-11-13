using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteILine : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public DeleteILine(IIngredientLineService ingredientLineService, int ingredientId, int recipeId)
        {
            _ingredientLineService = ingredientLineService;
            IngredientId = ingredientId;
            RecipeId = recipeId;
        }

        //[BindProperty(SupportsGet = true)]
        public int IngredientId { get; set; }

        //[BindProperty(SupportsGet = true)]
        public int RecipeId { get; set; }

        public IActionResult OnGet(int id)
        {
            IngredientLine ingredientLine = _ingredientLineService.GetById(id);

            Recipe recipe = new();
            recipe.Id = ingredientLine.Recipe.Id;

            _ingredientLineService.Delete(id);
            return RedirectToPage("/Recipes/AddIngredients", new { id = recipe.Id });
        }
    }
}
