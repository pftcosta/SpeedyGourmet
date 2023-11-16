using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetById : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientLineService _ingredientLineService;
        private readonly IPostService _postService;

        public GetById(IRecipeService recipeService, IIngredientLineService ingredientLineService, IPostService postService)
        {
            _recipeService = recipeService;
            _ingredientLineService = ingredientLineService;
            _postService = postService;
        }

        public List<Post> Posts { get; private set; }
        public Recipe Recipe { get; private set; }
        public User User { get; set; }

        public void OnGet(int recipeId)
        {
            GetUser();
            Recipe = _recipeService.GetById(recipeId);
            Recipe.Ingredients.AddRange(_ingredientLineService.GetAllByRecipeId(recipeId));
            Posts = _postService.GetAllByRecipeId(recipeId);
        }

        public void OnPost()
        {
            Post post = new Post()
            {
                Comment = Convert.ToString(Request.Form["comment"]),
                Rating = Convert.ToInt32(Request.Form["rating"]),
                User = new User { Id = Convert.ToInt32(Request.Form["id_user"]), },
                Recipe = new Recipe { Id = Convert.ToInt32(Request.Form["id_recipe"]), }
            };

            _postService.Create(post);
            OnGet(post.Recipe.Id);
            //return RedirectToPage("/Recipes/GetById", new { id = recipeId });
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

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
