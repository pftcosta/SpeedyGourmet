using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class DeleteAllByRecipe : PageModel
    {
        private readonly IPostService _postService;

        public DeleteAllByRecipe(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult OnGet(int id)
        {
            _postService.DeleteAllByRecipeId(id);
            return Redirect("/Posts/GetAllByRecipe");
        }
    }
}
