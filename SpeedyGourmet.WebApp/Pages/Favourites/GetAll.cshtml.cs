using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetAllModel : PageModel
    {
        private readonly IRecFavService<Favourite, int> _favouriteService;

        private readonly IService<User, int> _userService;

        private readonly IRecFavService<Recipe, int> _recipeService;

        public GetAllModel(IRecFavService<Favourite, int> favouriteService, IService<User, int> userService, IRecFavService<Recipe, int> recipeService)
        {
            _favouriteService = favouriteService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public List<Favourite> favourites = new();
        public List<User> users = new();
        public List<Recipe> recipes = new();
        public User user = new();

        public void OnGet()
        {
            favourites = _favouriteService.GetAll();
            users = _userService.GetAll();
            recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Favourite favourite = new();

            favourite.User = user;
            favourite.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            Recipe recipe = new();
            favourite.Recipe = recipe;
            favourite.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _favouriteService.Create(favourite);
            OnGet();
        }
    }
}
