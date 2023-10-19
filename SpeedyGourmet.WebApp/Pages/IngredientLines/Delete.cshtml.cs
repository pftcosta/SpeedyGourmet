using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class DeleteModel : PageModel
    {
        private readonly IILPostService<IngredientLine, int> _iLService;

        public DeleteModel(IILPostService<IngredientLine, int> iLService)
        {
            _iLService = iLService;
        }

        public IActionResult OnGet(int id)
        {
            _iLService.Delete(id);
            return Redirect("/IngredientLines/GetAll");
        }
    }
}
