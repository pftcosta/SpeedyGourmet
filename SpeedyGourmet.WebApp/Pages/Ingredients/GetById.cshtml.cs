using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class GetById : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public GetById(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public Ingredient Ingredient { get; private set; }
        public User User { get; set; }

        public void OnGet(int ingredientId)
        {
            GetUser();
            Ingredient = _ingredientService.GetById(ingredientId);
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
