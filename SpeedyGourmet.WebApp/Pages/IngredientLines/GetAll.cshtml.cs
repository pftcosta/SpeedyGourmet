using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAllModel : PageModel
    {

        private readonly IILPostService<IngredientLine, int> _iLService;

        private readonly IService<Ingredient, int> _ingredientService;

        private readonly IService<Measure, int> _measureService;

        private readonly IService<Recipe, int> _recipeService;

        public GetAllModel(IILPostService<IngredientLine, int> iLService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IService<Recipe, int> recipeService)
        {
            _iLService = iLService;
            _ingredientService = ingredientService;
            _measureService = measureService;
            _recipeService = recipeService;
        }

        public List<IngredientLine> ingredientLines = new();

        public List<Ingredient> ingredients = new();

        public List<Measure> measures = new();

        public void OnGet()
        {
            ingredientLines = _iLService.GetAll();
            ingredients = _ingredientService.GetAll();
            measures = _measureService.GetAll();
        }

        public void OnPost()
        {
            IngredientLine ingredientLine = new();
            ingredientLine.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            Ingredient ingredient = new();
            ingredientLine.Ingredient = ingredient;
            ingredientLine.Ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);

            Measure measure = new();
            ingredientLine.Measure = measure;
            ingredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            Recipe recipe = new();
            recipe = _recipeService.GetById(1);
            ingredientLine.Recipe = recipe;
            //ingredientLine.Measure.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _iLService.Create(ingredientLine);

            OnGet();
        }
    }
}
