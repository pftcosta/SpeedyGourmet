using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetAll : PageModel
    {
        private readonly IFavouriteService _favouriteService;
        private readonly IUserService _userService;

        private readonly IRecipeService _recipeService;

        public GetAll(IFavouriteService favouriteService, IUserService userService, IRecipeService recipeService, List<Favourite> favourites, List<User> users, List<Recipe> recipes, User user)
        {
            _favouriteService = favouriteService;
            _userService = userService;
            _recipeService = recipeService;
            Favourites = favourites;
            Users = users;
            Recipes = recipes;
            User = user;
        }

        public List<Favourite> Favourites { get; set; }
        public List<User> Users { get; set; }
        public List<Recipe> Recipes { get; set; }
        public User User { get; set; }

        public void OnGet()
        {
            Favourites = _favouriteService.GetAll();
            Favourites = Favourites.OrderBy(p => p.User.Name).ToList();

            Users = _userService.GetAll();
            Recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Favourite favourite = new();

            favourite.User = User;
            favourite.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            Recipe recipe = new();
            favourite.Recipe = recipe;
            favourite.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);

            _favouriteService.Create(favourite);
            OnGet();
        }
    }
}
