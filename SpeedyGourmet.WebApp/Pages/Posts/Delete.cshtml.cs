using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class Delete : PageModel
    {
        private readonly IPostService _postService;

        public Delete(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult OnGet(int postId)
        {
            _postService.Delete(postId);
            return Redirect("/Posts/GetAll");
        }
    }
}
