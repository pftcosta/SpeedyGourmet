using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetById : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        public GetById(IFavouriteService favouriteService, Favourite favourite)
        {
            _favouriteService = favouriteService;
            Favourite = favourite;
        }

        public Favourite Favourite { get; set; }

        public void OnGet(int id)
        {
            Favourite = _favouriteService.GetById(id);
        }

        public void OnPost(int id)
        {
            RedirectToPage("/Favourites/GetAllByUser", new { id = id });
        }
    }
}
