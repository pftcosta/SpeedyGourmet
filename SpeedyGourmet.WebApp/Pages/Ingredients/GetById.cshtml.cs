using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class GetByIdModel : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public GetByIdModel(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public Ingredient ingredient = new();

        public void OnGet(int id)
        {
            ingredient = _ingredientService.GetById(id);
        }
    }
}
