using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class GetAll : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public GetAll(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public List<Ingredient> Ingredients { get; set; }

        public Ingredient Ingredient { get; set; }

        public void OnGet()
        {
            Ingredients = _ingredientService.GetAll();
        }

        public void OnPost()
        {
            Ingredient.Name = Convert.ToString(Request.Form["name"]);
            _ingredientService.Create(Ingredient);
            OnGet();
        }
    }
}
