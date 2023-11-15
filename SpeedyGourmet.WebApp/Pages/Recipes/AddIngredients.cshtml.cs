using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class AddIngredients : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecipeService _recipeService;
        private readonly IIngredientLineService _ingredientLineService;

        public AddIngredients(IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecipeService recipeService, IIngredientLineService ingredientLineService)
        {
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
        }

        public List<Ingredient> Ingredients { get; private set; }
        public List<Measure> Measures { get; private set; }
        public Recipe Recipe { get; private set; }
        public User User { get; set; }

        public void OnGet(int recipeId)
        {
            GetUser();
            Recipe = _recipeService.GetById(recipeId);
            Ingredients = _ingredientService.GetAll();
            Measures = _measureService.GetAll();
        }

        public void OnPost(int recipeId)
        {
            IngredientLine ingredientLine = new IngredientLine()
            {
                Recipe = _recipeService.GetById(recipeId),
                Quantity = Convert.ToInt32(Request.Form["quantity"]),
                Ingredient = new Ingredient { Id = Convert.ToInt32(Request.Form["id_ingredient"]) },
                Measure = new Measure { Id = Convert.ToInt32(Request.Form["id_measure"]) }
            };

            _ingredientLineService.Create(ingredientLine);
            ingredientLine.Recipe.Ingredients.Add(ingredientLine);
            _recipeService.Update(ingredientLine.Recipe);

            //return RedirectToPage("/Recipes/AddIngredients", new { id = recipeId });
            OnGet(recipeId);
        }

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
