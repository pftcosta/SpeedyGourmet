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
        private readonly IRecFavService<Recipe, int> _recipeService;
        private readonly IILPostService<IngredientLine, int> _ingredientLineService;

        public AddIngredientsModel(IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecFavService<Recipe, int> recipeService, IILPostService<IngredientLine, int> ingredientLineService)
        {
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
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
            Recipe recipe = _recipeService.GetById(id);

            IngredientLine ingredientLine = new();
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
