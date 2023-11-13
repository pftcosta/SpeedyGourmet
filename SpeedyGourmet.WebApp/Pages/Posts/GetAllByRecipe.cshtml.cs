using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAllByRecipe : PageModel
    {
        private readonly IPostService _postService;
        private readonly IRecipeService _recipeService;

        public GetAllByRecipe(IPostService postService, IRecipeService recipeService, List<Post> posts, List<Recipe> recipes, Recipe recipe, User user)
        {
            _postService = postService;
            _recipeService = recipeService;
            Posts = posts;
            Recipes = recipes;
            Recipe = recipe;
            User = user;
        }

        public List<Post> Posts { get; set; }
        public List<Recipe> Recipes { get; set; }
        public Recipe Recipe { get; set; }
        public User User { get; set; }

        public void OnGet(int id)
        {
            Posts = _postService.GetAllByRecipeId(id);
            Recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Post post = new Post();
            post.Recipe = Recipe;
            post.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            OnGet(post.Recipe.Id);
        }
    }
}
