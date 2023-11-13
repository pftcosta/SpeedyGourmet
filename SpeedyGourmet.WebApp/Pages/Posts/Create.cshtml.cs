using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly IIIngredientLineService<Post, int> _iLPostService;

        private readonly IRecipeService<Recipe, int> _recipeService;

        private readonly IService<User, int> _userService;

        public CreateModel(IIIngredientLineService<Post, int> iLPostService, IRecipeService<Recipe, int> recipeService, IService<User, int> userService)
        {
            _iLPostService = iLPostService;
            _recipeService = recipeService;
            _userService = userService;
        }

        public List<Post> posts = new();
        public List<User> users = new();
        public List<Recipe> recipes = new();

        public Post post = new();

        public void OnGet()
        {
            posts = _iLPostService.GetAll();
            recipes = _recipeService.GetAll();
            users = _userService.GetAll();
        }


    }
}
