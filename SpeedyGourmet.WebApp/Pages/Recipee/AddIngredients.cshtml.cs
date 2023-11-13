using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class AddIngredientsModel : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecipeService<Recipe, int> _recipeService;
        private readonly IIIngredientLineService<IngredientLine, int> _ingredientLineService;

        public AddIngredientsModel(IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecipeService<Recipe, int> recipeService, IIIngredientLineService<IngredientLine, int> ingredientLineService)
        {
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
        }

        public List<Ingredient> Ingredients { get; set; }
        public List<Measure> Measures { get; set; }
        public Recipe recipe = new();

        public void OnGet(int id)
        {
            recipe = _recipeService.GetById(id);
            Ingredients = _ingredientService.GetAll();
            Measures = _measureService.GetAll();
        }

        public IActionResult OnPost(int id)
        {
            recipe = _recipeService.GetById(id);

            IngredientLine ingredientLine = new IngredientLine();
            ingredientLine.Recipe = recipe;

            ingredientLine.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            ingredientLine.Ingredient = new Ingredient();
            ingredientLine.Ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);

            ingredientLine.Measure = new Measure();
            ingredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            ingredientLine = _ingredientLineService.Create(ingredientLine);

            recipe.Ingredients.Add(ingredientLine);
            recipe = _recipeService.Update(recipe);

            return RedirectToPage("/Recipee/AddIngredients", new { id = recipe.Id });
        }
    }
}
