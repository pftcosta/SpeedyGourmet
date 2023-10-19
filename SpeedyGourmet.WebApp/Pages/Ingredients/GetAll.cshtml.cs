using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class GetAllModel : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public GetAllModel(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public List<Ingredient> ingredients { get; set; }

        public Ingredient ingredient = new();

        public void OnGet()
        {
            ingredients = _ingredientService.GetAll();
        }

        public void OnPost()
        {
            ingredient.Name = Convert.ToString(Request.Form["name"]);
            _ingredientService.Create(ingredient);
            OnGet();
        }
    }
}
