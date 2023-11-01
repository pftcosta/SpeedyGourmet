using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetAllByUserModel : PageModel
    {
        private readonly IILPostService<Post, int> _iLPostService;
        private readonly IService<User, int> _userService;
        private readonly IRecFavService<Recipe, int> _recipeService;

        public GetAllByUserModel(IILPostService<Post, int> iLPostService, IService<User, int> userService, IRecFavService<Recipe, int> recipeService)
        {
            _iLPostService = iLPostService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public List<Post> posts = new();
        public List<Recipe> recipes = new();
        public List<User> users = new();
        public Recipe recipe = new();
        public User user = new();
        public Post post = new();

        public void OnGet(int id)
        {
            posts = _iLPostService.GetAllByUserId(id);
            recipes = _recipeService.GetAll();
            users = _userService.GetAll();
        }

        public void OnPost()
        {
            post.User = user;
            post.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            OnGet(post.User.Id);
        }
    }
}
