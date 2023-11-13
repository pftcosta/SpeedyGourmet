using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAllModel : PageModel
    {
        private readonly IIIngredientLineService<Post, int> _iLPostService;
        private readonly IService<User, int> _userService;
        private readonly IRecipeService<Recipe, int> _recipeService;

        public GetAllModel(IIIngredientLineService<Post, int> iLPostService, IService<User, int> userService, IRecipeService<Recipe, int> recipeService)
        {
            _iLPostService = iLPostService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public List<Post> posts = new();
        public List<User> users = new();
        public List<Recipe> recipes = new();

        public Recipe recipe = new();

        public void OnGet()
        {
            posts = _iLPostService.GetAll();
            users = _userService.GetAll();
            recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Post post = new();
            post.Comment = Convert.ToString(Request.Form["comment"]);
            post.Rating = Convert.ToInt32(Request.Form["rating"]);

            User user = new();
            post.User = user;
            post.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            post.Recipe = recipe;
            post.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _iLPostService.Create(post);
            OnGet();
        }
    }
}
