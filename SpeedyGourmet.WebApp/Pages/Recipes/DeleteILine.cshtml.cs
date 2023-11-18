using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteILine : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public DeleteILine(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public User User { get; set; }

        public IActionResult OnGet(int ingredientId, int recipeId)
        {
            GetUser();
            IngredientLine ingredientLine = _ingredientLineService.GetById(ingredientId);
            int id = recipeId;

            _ingredientLineService.Delete(ingredientId);
            return RedirectToPage("/Recipes/AddIngredients", new { recipeId = id });
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
