using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class Delete : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public Delete(IIngredientLineService ingredientLineService, IngredientLine ingredientLine)
        {
            _ingredientLineService = ingredientLineService;
            IngredientLine = ingredientLine;
        }

        public IngredientLine IngredientLine { get; set; }

        public IActionResult OnGet(int id)
        {
            _ingredientLineService.Delete(id);
            return RedirectToPage("/IngredientLines/GetAllByRecipe", new { id = id });
        }
    }
}
