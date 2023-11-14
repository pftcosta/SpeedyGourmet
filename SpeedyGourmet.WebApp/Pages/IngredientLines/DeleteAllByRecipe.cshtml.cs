using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class DeleteAllByRecipe : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public DeleteAllByRecipe(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public IActionResult OnGet(int recipeId)
        {
            _ingredientLineService.DeleteAllByRecipeId(recipeId);
            return Redirect("/IngredientLines/GetAllByRecipe");
        }
    }
}
