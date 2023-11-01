using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class DeleteAllByRecipeModel : PageModel
    {
        private readonly IILPostService<IngredientLine, int> _ilService;

        public DeleteAllByRecipeModel(IILPostService<IngredientLine, int> ilService)
        {
            _ilService = ilService;
        }

        public IngredientLine ingredientLine = new();

        public IActionResult OnGet(int id)
        {
            _ilService.DeleteAllByRecipeId(id);
            return Redirect("/IngredientLines/GetAllByRecipe");
        }
    }
}
