using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteILineModel : PageModel
    {
        private readonly IIIngredientLineService<IngredientLine, int> _iLService;

        public DeleteILineModel(IIIngredientLineService<IngredientLine, int> iLService)
        {
            _iLService = iLService;
        }

        //[BindProperty(SupportsGet = true)]
        public int IngredientId { get; set; }

        //[BindProperty(SupportsGet = true)]
        public int RecipeId { get; set; }

        public IActionResult OnGet(int id)
        {
            IngredientLine ingredientLine = _iLService.GetById(id);

            Recipe recipe = new();
            recipe.Id = ingredientLine.Recipe.Id;

            _iLService.Delete(id);
            return RedirectToPage("/Recipee/AddIngredients", new { id = recipe.Id });
        }
    }
}
