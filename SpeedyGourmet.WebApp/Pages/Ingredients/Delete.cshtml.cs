using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class Delete : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public Delete (IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }
        public User User { get; set; }

        public IActionResult OnGet(int ingredientId)
        {
            GetUser();
            _ingredientService.Delete(ingredientId);
            return Redirect("/Ingredients/GetAll");
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
