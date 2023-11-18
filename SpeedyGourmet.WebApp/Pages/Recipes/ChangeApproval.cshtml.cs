using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipes
{
    public class ChangeApprovalModel : PageModel
    {
        private readonly IRecipeService _recipeService;

        public ChangeApprovalModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult OnGet(int id)
        {
            Recipe recipe = _recipeService.GetById(id);
            recipe.IsApproved = !recipe.IsApproved;
            _recipeService.Update(recipe);
            return RedirectToPage("/Recipes/GetAll");
        }
    }
}
