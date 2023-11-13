using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAllByUser : PageModel
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public GetAllByUser(IPostService postService, IUserService userService, List<Post> posts, List<User> users)
        {
            _postService = postService;
            _userService = userService;
            Posts = posts;
            Users = users;
        }

        public List<Post> Posts { get; set; }
        public List<User> Users { get; set; }

        public void OnGet(int id)
        {
            Posts = _postService.GetAllByUserId(id);
            Users = _userService.GetAll();
        }

        public void OnPost()
        {
            Post post = new Post();
            post.User = new User();
            post.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            OnGet(post.User.Id);
        }
    }
}
