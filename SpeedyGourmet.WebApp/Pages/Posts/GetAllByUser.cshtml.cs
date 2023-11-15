using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAllByUser : PageModel
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public GetAllByUser(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        public List<Post> Posts { get; private set; }
        public List<User> Users { get; private set; }
        public Recipe Recipe { get; private set; }
        public User User { get; private set; }

        public void OnGet(int userId)
        {
            GetUser();
            Posts = _postService.GetAllByUserId(userId);
            Users = _userService.GetAll();
        }

        public void OnPost()
        {
            int userId = Convert.ToInt32(Request.Form["id_user"]);
            OnGet(userId);
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
