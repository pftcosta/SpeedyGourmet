using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Service;
using SpeedyGourmet.Model;

namespace SpeedyGourmet.WebApp.Pages.Recipes
{
    public class GetAllModel : PageModel
    {
        private readonly IService<Recipe, int> _recipeService;

        public GetAllModel(IService<Recipe, int> recipeService)
        {
            _recipeService = recipeService;
        }

        public List<Recipe> recipes { get; set; }

        public void OnGet()
        {
            recipes = _recipeService.GetAll();
        }
    }
}
