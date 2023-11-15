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

        public GetAllByRecipe(IPostService postService, IRecipeService recipeService)
        {
            _postService = postService;
            _recipeService = recipeService;
        }

        public List<Post> Posts { get; private set; }
        public List<Recipe> Recipes { get; private set; }
        public Recipe Recipe { get; private set; }
        public User User { get; private set; }

        public void OnGet(int recipeId)
        {
            Posts = _postService.GetAllByRecipeId(recipeId);
            Recipes = _recipeService.GetAll();
            MathRound();
        }

        public void OnPost()
        {
            int recipeId = Convert.ToInt32(Request.Form["id_recipe"]);
            OnGet(recipeId);
        }

        public double MathRound()
        {
            double totalRating = 0.0;
            foreach (Post post in Posts)
            {
                totalRating += post.Rating;
            }
            double averageRating = totalRating / Posts.Count;
            return Math.Round(averageRating, 2);
        }
    }
}
