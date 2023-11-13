using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class GetById : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public GetById(IService<Ingredient, int> ingredientService, Ingredient ingredient)
        {
            _ingredientService = ingredientService;
            Ingredient = ingredient;
        }

        public Ingredient Ingredient { get; set; }

        public void OnGet(int id)
        {
            Ingredient = _ingredientService.GetById(id);
        }
    }
}
