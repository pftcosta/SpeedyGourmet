using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class CreateByRecipe : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IRecipeService _recipeService;

        public CreateByRecipe(IIngredientLineService ingredientLineService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IRecipeService recipeService)
        {
            _ingredientLineService = ingredientLineService;
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
        }

        public List<IngredientLine> IngredientLines { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<Measure> Measures { get; private set; }
        public List<Recipe> Recipes { get; private set; }
        public IngredientLine IngredientLine { get; private set; }
        public Recipe Recipe { get; private set; }
        public User User { get; set; }

        public void OnGet(int recipeId)
        {
            GetUser();
            IngredientLine.Recipe = _recipeService.GetById(recipeId);
            IngredientLines = _ingredientLineService.GetAllByRecipeId(recipeId);
            Recipes = _recipeService.GetAll();
            Ingredients = _ingredientService.GetAll();
            Measures = _measureService.GetAll();
        }

        public void OnPost(int recipeId)
        {
            IngredientLine = new IngredientLine
            {
                Quantity = Convert.ToInt32(Request.Form["quantity"]),
                Ingredient = new Ingredient { Id = Convert.ToInt32(Request.Form["id_ingredient"]) },
                Measure = new Measure { Id = Convert.ToInt32(Request.Form["id_measure"]) },
                Recipe = new Recipe { Id = Convert.ToInt32(Request.Form["id_recipe"]) }
            };

            _ingredientLineService.Create(IngredientLine);
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
