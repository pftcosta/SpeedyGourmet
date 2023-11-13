using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class DeleteModel : PageModel
    {
        private readonly IIIngredientLineService<IngredientLine, int> _ilService;

        public DeleteModel(IIIngredientLineService<IngredientLine, int> ilService)
        {
            _ilService = ilService;
        }

        public IngredientLine ingredientLine = new();

        public IActionResult OnGet(int id)
        {
            _ilService.Delete(id);
            return RedirectToPage("/IngredientLines/GetAllByRecipe", new { id = id });
        }
    }
}
