using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService<Favourite, int> _favouriteService;

        public DeleteModel(IRecipeService<Favourite, int> favouriteService)
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
