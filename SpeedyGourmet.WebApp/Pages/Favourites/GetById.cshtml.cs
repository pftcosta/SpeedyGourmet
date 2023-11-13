using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetByIdModel : PageModel
    {
        private readonly IRecipeService<Favourite, int> _favouriteService;

        public GetByIdModel(IRecipeService<Favourite, int> favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public Favourite favourite = new();

        public void OnGet(int id)
        {
            favourite = _favouriteService.GetById(id);
        }

        public void OnPost(int id)
        {
            RedirectToPage("/Favourites/GetAllByUser", new { id = id });
        }
    }
}
