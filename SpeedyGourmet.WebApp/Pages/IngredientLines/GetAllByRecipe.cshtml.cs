using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAllByRecipeModel : PageModel
    {
        private readonly IILPostService<IngredientLine, int> _iLService;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecFavService<Recipe, int> _recipeService;

        public GetAllByRecipeModel(IILPostService<IngredientLine, int> iLService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecFavService<Recipe, int> recipeService)
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
            if ( id == 0)
            {
                id = 1;
            }
            ingredientLines = _iLService.GetAllByRecipeId(id);
            recipes = _recipeService.GetAll();
            ingredientLine.Recipe = _recipeService.GetById(id);
        }

        public void /*IActionResult*/ OnPost()
        {
            //ingredientLine.Recipe = recipe;
            //ingredientLine.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            //OnGet(ingredientLine.Recipe.Id);

            //return RedirectToPage("/IngredientLines/CreateByRecipe", new { id = recipe.Id });

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

            OnGet(ingredientLine.Recipe.Id);
        }
    }
}
