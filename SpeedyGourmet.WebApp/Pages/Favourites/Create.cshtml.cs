using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class CreateModel : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        public CreateModel(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public User User { get; private set; }

        public void OnGet()
        {
            GetUser();
        }

        public void OnPost(int id_user, int id_recipe)
        {
            Favourite favourite = new();
            User user = new User();
            favourite.User = user;
            favourite.User.Id = id_user;

            Recipe recipe = new();
            favourite.Recipe = recipe;
            favourite.Recipe.Id = id_recipe;
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
