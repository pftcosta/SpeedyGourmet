using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetAllModel : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        public GetAllModel(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public List<Favourite> favourites = new();


        public void OnGet()
        {
            favourites = _favouriteService.GetAll();
        }

        public void OnPost()
        {
            Favourite favourite = new();

            User user = new();
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
