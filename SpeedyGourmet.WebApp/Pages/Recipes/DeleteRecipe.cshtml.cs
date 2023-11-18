using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteRecipe : PageModel
    {
        private readonly IRecipeService _recipeService;

        public DeleteRecipe(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public User User { get; set; }

        public IActionResult OnGet(int recipeId)
        {
            GetUser();
            _recipeService.Delete(recipeId);
            return Redirect("/Index");
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
