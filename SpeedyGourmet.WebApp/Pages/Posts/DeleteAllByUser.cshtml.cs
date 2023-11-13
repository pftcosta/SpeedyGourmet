using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class DeleteAllByUser : PageModel
    {
        private readonly IPostService _postService;

        public DeleteAllByUser(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult OnGet(int id)
        {
            _postService.DeleteAllByUserId(id);
            return Redirect("/Posts/GetAllByUser");
        }
    }
}
