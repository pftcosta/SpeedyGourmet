using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class DeleteAllByRecipe : PageModel
    {
        private readonly IPostService _postService;

        public DeleteAllByRecipe(IPostService postService)
        {
            _postService = postService;
        }
        public User User { get; set; }

        public IActionResult OnGet(int recipeId)
        {
            GetUser();
            _postService.DeleteAllByRecipeId(recipeId);
            return Redirect("/Posts/GetAllByRecipe");
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
