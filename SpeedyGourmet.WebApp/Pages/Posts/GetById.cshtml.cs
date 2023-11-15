using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetByIdModel : PageModel
    {
        private readonly IPostService _postService;

        public GetByIdModel(IPostService postService)
        {
            _postService = postService;
        }

        public Post Post { get; private set; }

        public void OnGet(int postId)
        {
            Post = _postService.GetById(postId);
        }
    }
}
