using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly IService<Recipe, int> _recipeService;

        public CreateModel(IService<Recipe, int> recipeService)
        {
            _recipeService = recipeService;
        }

        public void OnPost()
        {

        }
    }
}
