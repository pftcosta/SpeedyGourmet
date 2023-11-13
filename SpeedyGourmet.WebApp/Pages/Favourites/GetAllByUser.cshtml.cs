using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetAllByUser : PageModel
    {
        private readonly IFavouriteService _favouriteService;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        public GetAllByUser(IFavouriteService favouriteService, IUserService userService, IRecipeService recipeService, List<Favourite> favourites, List<User> users, List<Recipe> recipes, User user)
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

        public void OnGet(int id)
        {
            Favourites = _favouriteService.GetAllByUserId(id);
            Users = _userService.GetAll();
            Recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Favourite favourite = new();

            favourite.User = User;
            favourite.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            OnGet(favourite.User.Id);
        }
    }
}

