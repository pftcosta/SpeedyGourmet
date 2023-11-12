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
        public IngredientLine IngredientLine { get; set; }
        public Recipe recipe = new();

        public void OnGet(int id)
        {
            recipe = _recipeService.GetById(id);
            recipe.Ingredients = _ingredientLineService.GetAllByRecipeId(id);

            Ingredients = _ingredientService.GetAll();
            Measures = _measureService.GetAll();
        }

        public IActionResult OnPost()
        {
            IngredientLine.Recipe = recipe;
            IngredientLine.Recipe.Id = Convert.ToInt32(Request.Form["recipeid"]);

            IngredientLine.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            IngredientLine.Ingredient = new Ingredient();
            IngredientLine.Ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);

            IngredientLine.Measure = new Measure();
            IngredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            IngredientLine = _ingredientLineService.Create(IngredientLine);

            IngredientLine.Recipe.Ingredients.Add(IngredientLine);

            recipe.Ingredients = _ingredientLineService.GetAllByRecipeId(IngredientLine.Recipe.Id);

            _recipeService.Update(recipe);

            //OnGet(recipe.Id);
            return RedirectToPage("/Recipee/AddIngredients", new { id = IngredientLine.Recipe.Id });
        }
    }
}
