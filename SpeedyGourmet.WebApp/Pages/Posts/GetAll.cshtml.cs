using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAll : PageModel
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        public GetAll (IPostService postService, IUserService userService, IRecipeService recipeService, List<Post> posts, List<User> users, List<Recipe> recipes, Recipe recipe)
        {
            _postService = postService;
            _userService = userService;
            _recipeService = recipeService;
            Posts = posts;
            Users = users;
            Recipes = recipes;
            Recipe = recipe;
        }

        public List<Post> Posts { get; set; }
        public List<User> Users { get; set; }
        public List<Recipe> Recipes { get; set; }
        public Recipe Recipe { get; set; }

        public void OnGet()
        {
            Posts = _postService.GetAll();
            Users = _userService.GetAll();
            Recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Post post = new();
            post.Comment = Convert.ToString(Request.Form["comment"]);
            post.Rating = Convert.ToInt32(Request.Form["rating"]);

            User user = new();
            post.User = user;
            post.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            post.Recipe = Recipe;
            post.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _postService.Create(post);
            OnGet();
        }
    }
}
