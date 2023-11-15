using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class DeleteAllByRecipe : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public DeleteAllByRecipe(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public User User { get; set; }

        public IActionResult OnGet(int recipeId)
        {
            GetUser();
            _ingredientLineService.DeleteAllByRecipeId(recipeId);
            return Redirect("/IngredientLines/GetAllByRecipe");
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
