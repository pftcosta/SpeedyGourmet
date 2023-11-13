using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class CreateByRecipeModel : PageModel
    {
        private readonly IIIngredientLineService<IngredientLine, int> _iLService;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecipeService<Recipe, int> _recipeService;

        public CreateByRecipeModel(IIIngredientLineService<IngredientLine, int> iLService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecipeService<Recipe, int> recipeService)
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

        public void OnGet(int id)
        {
            ingredientLine.Recipe = _recipeService.GetById(id);
            ingredientLines = _iLService.GetAllByRecipeId(id);
            recipes = _recipeService.GetAll();
            ingredients = _ingredientService.GetAll();
            measures = _measureService.GetAll();
        }

        public void OnPost(int id)
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

            OnGet(id);
        }
    }
}
