using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class Delete : PageModel
    {
        private readonly IRecipeService _favouriteService;

        public Delete (IRecipeService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public IActionResult OnGet(int favouriteId)
        {
            _favouriteService.Delete(favouriteId);
            return Redirect("/Favourites/GetAll");
        }
    }
}
