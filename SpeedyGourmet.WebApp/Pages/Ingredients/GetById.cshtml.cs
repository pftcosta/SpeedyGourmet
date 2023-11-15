using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class GetById : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public GetById(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public Ingredient Ingredient { get; private set; }

        public void OnGet(int ingredientId)
        {
            Ingredient = _ingredientService.GetById(ingredientId);
        }
    }
}
