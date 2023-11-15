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

        public IActionResult OnGet(int ingredientId)
        {
            GetUser();
            IngredientLine ingredientLine = _ingredientLineService.GetById(ingredientId);

            _ingredientLineService.Delete(ingredientId);
            return RedirectToPage("/Recipes/AddIngredients", new { id = ingredientLine.Recipe.Id });
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
