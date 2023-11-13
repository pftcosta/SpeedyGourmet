using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class AddIngredients : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecipeService _recipeService;
        private readonly IIngredientLineService _ingredientLineService;

        public AddIngredients(IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecipeService recipeService, IIngredientLineService ingredientLineService, List<Ingredient> ingredients, List<Measure> measures, Recipe recipe)
        {
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
            Ingredients = ingredients;
            Measures = measures;
            Recipe = recipe;
        }

        public List<Ingredient> Ingredients { get; set; }
        public List<Measure> Measures { get; set; }
        public Recipe Recipe { get; set; }

        public void OnGet(int id)
        {
            Recipe = _recipeService.GetById(id);
            Ingredients = _ingredientService.GetAll();
            Measures = _measureService.GetAll();
        }

        public IActionResult OnPost(int id)
        {
            Recipe = _recipeService.GetById(id);

            IngredientLine ingredientLine = new IngredientLine();
            ingredientLine.Recipe = Recipe;

            ingredientLine.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            ingredientLine.Ingredient = new Ingredient();
            ingredientLine.Ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);

            ingredientLine.Measure = new Measure();
            ingredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            ingredientLine = _ingredientLineService.Create(ingredientLine);

            Recipe.Ingredients.Add(ingredientLine);
            Recipe = _recipeService.Update(Recipe);

            return RedirectToPage("/Recipes/AddIngredients", new { id = Recipe.Id });
        }
    }
}
