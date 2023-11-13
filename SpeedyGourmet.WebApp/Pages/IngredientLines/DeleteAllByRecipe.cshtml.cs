using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class DeleteAllByRecipe : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public DeleteAllByRecipe(IIngredientLineService ingredientLineService, IngredientLine ingredientLine)
        {
            _ingredientLineService = ingredientLineService;
            this.ingredientLine = ingredientLine;
        }

        public IngredientLine ingredientLine { get; set; }

        public IActionResult OnGet(int id)
        {
            _ingredientLineService.DeleteAllByRecipeId(id);
            return Redirect("/IngredientLines/GetAllByRecipe");
        }
    }
}
