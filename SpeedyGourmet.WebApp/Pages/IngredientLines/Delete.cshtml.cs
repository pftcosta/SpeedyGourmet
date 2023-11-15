using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.IngredientLines
{
    public class Delete : PageModel
    {
        private readonly IIngredientLineService _ingredientLineService;

        public Delete(IIngredientLineService ingredientLineService)
        {
            _ingredientLineService = ingredientLineService;
        }

        public User User { get; set; }

        public IActionResult OnGet(int ingredientLineId)
        {
            GetUser();
            _ingredientLineService.Delete(ingredientLineId);
            return RedirectToPage("/IngredientLines/GetAllByRecipe", new { id = ingredientLineId });
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
