using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteAllILines : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public DeleteAllILines(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public IActionResult OnGet(int recipeId)
        {
            _ingredientLineService.DeleteAllByRecipeId(recipeId);
            return RedirectToPage("/Recipes/AddIngredients", new {id = recipeId });
        }
    }
}
