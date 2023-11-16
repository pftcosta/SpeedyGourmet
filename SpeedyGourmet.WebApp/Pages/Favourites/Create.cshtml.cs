using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class CreateModel : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        public CreateModel(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public User User { get; private set; }

        public IActionResult OnGet(int userId, int recipeId)
        {
            GetUser();

            Favourite favourite = new Favourite
            {
                User = new User { Id = userId },
                Recipe = new Recipe { Id = recipeId }
            };

            _favouriteService.Create(favourite);
            return RedirectToPage("/Recipes/GetById", new { id = recipeId });
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
