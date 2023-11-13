using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class Delete : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public Delete (IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult OnGet(int id)
        {
            _ingredientService.Delete(id);
            return Redirect("/Ingredients/GetAll");
        }
    }
}
