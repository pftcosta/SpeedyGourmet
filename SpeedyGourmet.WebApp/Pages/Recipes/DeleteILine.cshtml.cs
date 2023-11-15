using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteILine : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public DeleteILine(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public IActionResult OnGet(int ingredientId)
        {
            IngredientLine ingredientLine = _ingredientLineService.GetById(ingredientId);

            _ingredientLineService.Delete(ingredientId);
            return RedirectToPage("/Recipes/AddIngredients", new { id = ingredientLine.Recipe.Id });
        }
    }
}
