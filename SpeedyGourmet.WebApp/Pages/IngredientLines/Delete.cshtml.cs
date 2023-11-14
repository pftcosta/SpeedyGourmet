using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class Delete : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public Delete(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public IActionResult OnGet(int ingredientLineId)
        {
            _ingredientLineService.Delete(ingredientLineId);
            return RedirectToPage("/IngredientLines/GetAllByRecipe", new { id = ingredientLineId });
        }
    }
}
