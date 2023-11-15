using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class DeleteAllByUser : PageModel
    {
        private readonly IPostService _postService;

        public DeleteAllByUser(IPostService postService)
        {
            _postService = postService;
        }
        public User User { get; set; }

        public IActionResult OnGet(int userId)
        {
            GetUser();
            _postService.DeleteAllByUserId(userId);
            return Redirect("/Posts/GetAllByUser");
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
