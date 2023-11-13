using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class GetByIdForUsersListModel : PageModel
    {
        private readonly IRecipeService<Favourite, int> _favouriteService;

        public GetByIdForUsersListModel(IRecipeService<Favourite, int> favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public Favourite favourite = new();

        public void OnGet(int id)
        {
            favourite = _favouriteService.GetById(id);
        }
        public IActionResult OnPost(int id)
        {
            return RedirectToPage("/Favourites/GetAllByUser", new { id = id });
        }
    }
}
