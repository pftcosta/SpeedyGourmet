using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteRecipe : PageModel
    {
        private readonly IRecipeService _recipeService;

        public DeleteRecipe(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult OnGet(int recipeId)
        {
            _recipeService.Delete(recipeId);
            return Redirect("/Recipes/GetAllByUserId");
        }
    }
}
