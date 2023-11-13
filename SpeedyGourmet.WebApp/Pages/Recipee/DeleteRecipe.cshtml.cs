using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class DeleteRecipeModel : PageModel
    {
        private readonly IRecipeService<Recipe, int> _recipeService;

        public DeleteRecipeModel(IRecipeService<Recipe, int> recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult OnGet(int id)
        {
            _recipeService.Delete(id);
            return Redirect("/Recipee/GetAllByUserId");
        }
    }
}
