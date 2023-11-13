using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAllByUserModel : PageModel
    {
        private readonly IIIngredientLineService<Post, int> _iLPostService;
        private readonly IService<User, int> _userService;

        public GetAllByUserModel(IIIngredientLineService<Post, int> iLPostService, IService<User, int> userService)
        {
            _iLPostService = iLPostService;
            _userService = userService;
        }

        public List<Post> posts = new();
        public List<User> users = new();

        public void OnGet(int id)
        {
            posts = _iLPostService.GetAllByUserId(id);
            users = _userService.GetAll();
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
