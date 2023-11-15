using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Favourites
{
    public class Delete : PageModel
    {
        private readonly IRecipeService _favouriteService;

        public Delete (IRecipeService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        public User User { get; set; }

        public IActionResult OnGet(int favouriteId)
        {
            GetUser();
            _favouriteService.Delete(favouriteId);
            return Redirect("/Favourites/GetAll");
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
