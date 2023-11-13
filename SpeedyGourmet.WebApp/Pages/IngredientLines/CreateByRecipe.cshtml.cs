using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class CreateByRecipe : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecipeService _recipeService;

        public CreateByRecipe(IIngredientLineService ingredientLineService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecipeService recipeService, List<IngredientLine> ingredientLines, List<Ingredient> ingredients, List<Measure> measures, List<Recipe> recipes, IngredientLine ingredientLine, Recipe recipe)
        {
            _ingredientLineService = ingredientLineService;
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
            IngredientLines = ingredientLines;
            Ingredients = ingredients;
            Measures = measures;
            Recipes = recipes;
            IngredientLine = ingredientLine;
            Recipe = recipe;
        }

        public List<IngredientLine> IngredientLines { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Measure> Measures { get; set; }
        public List<Recipe> Recipes { get; set; }
        public IngredientLine IngredientLine { get; set; }
        public Recipe Recipe { get; set; }

        public void OnGet(int id)
        {
            IngredientLine.Recipe = _recipeService.GetById(id);
            IngredientLines = _ingredientLineService.GetAllByRecipeId(id);
            Recipes = _recipeService.GetAll();
            Ingredients = _ingredientService.GetAll();
            Measures = _measureService.GetAll();
        }

        public void OnPost(int id)
        {
            IngredientLine.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            Ingredient ingredient = new();
            IngredientLine.Ingredient = ingredient;
            IngredientLine.Ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);

            Measure measure = new();
            IngredientLine.Measure = measure;
            IngredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            Recipe recipe = new();
            IngredientLine.Recipe = recipe;
            IngredientLine.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _ingredientLineService.Create(IngredientLine);

            OnGet(id);
        }
    }
}
