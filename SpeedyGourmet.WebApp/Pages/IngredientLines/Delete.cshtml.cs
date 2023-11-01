using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class DeleteModel : PageModel
    {
        private readonly IILPostService<IngredientLine, int> _ilService;

        public DeleteModel(IILPostService<IngredientLine, int> ilService)
        {
            _ilService = ilService;
        }

        public IngredientLine ingredientLine = new();

        public IActionResult OnGet(int id)
        {
            _ilService.Delete(id);
            return Redirect("/IngredientLines/GetAllByRecipe");
        }
    }
}
