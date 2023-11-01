using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteILineModel : PageModel
    {
        private readonly IILPostService<IngredientLine, int> _iLService;

        public DeleteILineModel(IILPostService<IngredientLine, int> iLService)
        {
            _iLService = iLService;
        }

        public IActionResult OnGet(int id)
        {
            _iLService.Delete(id);
            return Redirect("/Recipee/AddIngredients");
        }
    }
}
