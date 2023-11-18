using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetAll : PageModel
    {
        private readonly IFavouriteService _favouriteService;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        public GetAll(IFavouriteService favouriteService, IUserService userService, IRecipeService recipeService)
        {
            _favouriteService = favouriteService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public List<Favourite> Favourites { get; private set; }
        public List<User> Users { get; private set; }
        public List<Recipe> Recipes { get; private set; }
        public User User { get; private set; }
        public Recipe Recipe { get; private set; }

        public void OnGet()
        {
            GetUser();
            User = new User();
            Favourites = _favouriteService.GetAll().OrderBy(p => p.User.Id).ToList();
            Users = _userService.GetAll();
            Recipes = _recipeService.GetAll();
        }

        public void OnPost()
        {
            Favourite favourite = new();
            User user = new User();
            favourite.User = user;
            favourite.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            Recipe recipe = new();
            favourite.Recipe = recipe;
            favourite.Recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);
            _favouriteService.Create(favourite);
            OnGet();
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
