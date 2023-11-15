using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

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

        public void OnGet(int favouriteId)
        {
            Favourite = _favouriteService.GetById(favouriteId);
        }

        public void OnPost(int favouriteId)
        {
            RedirectToPage("/Favourites/GetAllByUser", new { id = favouriteId });
        }
    }
}
