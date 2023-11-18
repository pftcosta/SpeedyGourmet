using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class Delete : PageModel
    {
        private readonly IPostService _postService;

        public Delete(IPostService postService)
        {
            _postService = postService;
        }
        public User User { get; set; }

        public IActionResult OnGet(int postId, int userId)
        {
            GetUser();
            int id = userId;
            
            _postService.Delete(postId);
            return RedirectToPage("/Posts/GetAllByUser", new {userId = id});
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
