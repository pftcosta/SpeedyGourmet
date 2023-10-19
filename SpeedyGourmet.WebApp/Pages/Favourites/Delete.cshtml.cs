using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class DeleteModel : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        public DeleteModel(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public IActionResult OnGet(int id)
        {
            _favouriteService.Delete(id);
            return Redirect("/Favourites/GetAll");
        }
    }
}
