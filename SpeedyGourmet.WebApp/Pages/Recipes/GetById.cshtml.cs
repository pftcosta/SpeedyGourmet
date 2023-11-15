using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetById : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientLineService _ingredientLineService;

        public GetById(IRecipeService recipeService, IIngredientLineService ingredientLineService)
        {
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
        }

        public Recipe Recipe { get; private set; }
        public User User { get; set; }

        public void OnGet(int recipeId)
        {
            GetUser();
            Recipe = _recipeService.GetById(recipeId);
            Recipe.Ingredients.AddRange(_ingredientLineService.GetAllByRecipeId(recipeId));
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
