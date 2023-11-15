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

        public GetAllByUser(IFavouriteService favouriteService, IUserService userService, IRecipeService recipeService)
        {
            _favouriteService = favouriteService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public List<Favourite> Favourites { get; private set; }
        public List<User> Users { get; private set; }
        public List<Recipe> Recipes { get; private set; }

        public void OnGet(int userId)
        {
            Favourites = _favouriteService.GetAllByUserId(userId);
            Users = _userService.GetAll();
            Recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Favourite favourite = new Favourite()
            {
                User = new User { Id = Convert.ToInt32(Request.Form["id_user"]) }
            };

            OnGet(favourite.User.Id);
        }
    }
}

