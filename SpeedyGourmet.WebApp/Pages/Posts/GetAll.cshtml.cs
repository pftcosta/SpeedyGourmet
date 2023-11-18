using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAll : PageModel
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        public GetAll(IPostService postService, IUserService userService, IRecipeService recipeService)
        {
            _postService = postService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public List<Post> Posts { get; private set; }
        public List<User> Users { get; private set; }
        public List<Recipe> Recipes { get; private set; }
        public User User { get; private set; }

        public void OnGet()
        {
            GetUser();
            Posts = _postService.GetAll().OrderBy(p => p.User.Id).ToList();
            Users = _userService.GetAll();
            Recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Post post = new Post()
            {
                Comment = Convert.ToString(Request.Form["comment"]),
                Rating = Convert.ToInt32(Request.Form["rating"]),
                User = new User { Id = Convert.ToInt32(Request.Form["id_user"]) },
                Recipe = new Recipe { Id = Convert.ToInt32(Request.Form["id_recipe"]) }
            };

            _postService.Create(post);
            OnGet();
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
