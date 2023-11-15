using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class GetAllByRecipe : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IRecipeService _recipeService;

        public GetAllByRecipe(IIngredientLineService ingredientLineService, IRecipeService recipeService)
        {
            _ingredientLineService = ingredientLineService;
            _recipeService = recipeService;
        }

        public List<IngredientLine> IngredientLines { get; private set; }
        public List<Recipe> Recipes { get; private set; }
        public IngredientLine IngredientLine { get; private set; }
        public Recipe Recipe { get; private set; }
        public User User { get; set; }

        public void OnGet(int recipeId)
        {
            GetUser();
            IngredientLine.Recipe = _recipeService.GetById(recipeId);
            IngredientLines = _ingredientLineService.GetAllByRecipeId(recipeId);
        }

        public void OnPost()
        {
            int recipeId = Convert.ToInt32(Request.Form["id_recipe"]);
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
