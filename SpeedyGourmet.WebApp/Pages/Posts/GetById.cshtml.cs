using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

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
        public User User { get; set; }

        public void OnGet(int postId)
        {
            GetUser();
            Post = _postService.GetById(postId);
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
