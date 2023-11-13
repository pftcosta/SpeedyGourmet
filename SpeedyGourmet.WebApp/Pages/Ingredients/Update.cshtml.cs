using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class Update : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public Update(IService<Ingredient, int> ingredientService, Ingredient ingredient)
        {
            _ingredientService = ingredientService;
            Ingredient = ingredient;
        }

        public Ingredient Ingredient { get; set; }

        public void OnGet(int id)
        {
            Ingredient = _ingredientService.GetById(id);
        }

        public IActionResult OnPost()
        {
            Ingredient.Id = Convert.ToInt32(Request.Form["id"]);
            Ingredient.Name = Convert.ToString(Request.Form["name"]);
            _ingredientService.Update(Ingredient);
            return Redirect("/Ingredients/GetAll");
        }
    }
}
