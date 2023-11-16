using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly IPostService _postService;

        public CreateModel(IPostService postService)
        {
            _postService = postService;
        }

        public User User { get; private set; }

        public void OnGet()
        {
            GetUser();
        }

        public IActionResult OnPost(int userId, int recipeId)
        {
            Post post = new Post()
            {
                Comment = Convert.ToString(Request.Form["comment"]),
                Rating = Convert.ToInt32(Request.Form["rating"]),
                User = new User { Id = userId },
                Recipe = new Recipe { Id = recipeId }
            };

            _postService.Create(post);
            return RedirectToPage("/Recipes/GetById", new { id = recipeId });
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
