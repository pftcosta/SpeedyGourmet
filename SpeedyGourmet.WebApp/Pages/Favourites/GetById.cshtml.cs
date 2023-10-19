using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetByIdModel : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        public GetByIdModel(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public Favourite favourite = new();

        public void OnGet(int id)
        {
            favourite = _favouriteService.GetById(id);

        }
    }
}
