using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetById : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        public GetById(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public Favourite Favourite { get; private set; }
        public User User { get; set; }

        public void OnGet(int favouriteId)
        {
            GetUser();
            Favourite = _favouriteService.GetById(favouriteId);
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
