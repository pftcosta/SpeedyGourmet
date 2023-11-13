using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAllModel : PageModel
    {
        private readonly IIIngredientLineService<IngredientLine, int> _iLService;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecipeService<Recipe, int> _recipeService;

        public GetAllModel(IIIngredientLineService<IngredientLine, int> iLService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecipeService<Recipe, int> recipeService)
        {
            _iLService = iLService;
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
        }

        public List<IngredientLine> ingredientLines = new();
        public List<Ingredient> ingredients = new();
        public List<Measure> measures = new();
        public List<Recipe> recipes = new();

        public IngredientLine ingredientLine = new();
        public Recipe recipe = new();

        public void OnGet()
        {
            ingredientLines = _iLService.GetAll();
            ingredients = _ingredientService.GetAll();
            measures = _measureService.GetAll();
            recipes = _recipeService.GetAll();
        }

        public IActionResult OnPost()
        {
            ingredientLine.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            Ingredient ingredient = new();
            ingredientLine.Ingredient = ingredient;
            ingredientLine.Ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);

            Measure measure = new();
            ingredientLine.Measure = measure;
            ingredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            Recipe recipe = new();
            ingredientLine.Recipe = recipe;
            ingredientLine.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _iLService.Create(ingredientLine);

            //OnGet();

            return RedirectToPage("/IngredientLines/CreateRecipe", new { id = recipe.Id });
        }
    }
}
