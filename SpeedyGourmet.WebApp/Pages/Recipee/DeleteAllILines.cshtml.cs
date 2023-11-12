using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteAllILinesModel : PageModel
    {
        private readonly IILPostService<IngredientLine, int> _iLService;

        public DeleteAllILinesModel(IILPostService<IngredientLine, int> iLService)
        {
            _iLService = iLService;
        }

        public IActionResult OnGet(int id)
        {
            _iLService.DeleteAllByRecipeId(id);
            return RedirectToPage("/Recipee/AddIngredients", new {id = id});
        }
    }
}
