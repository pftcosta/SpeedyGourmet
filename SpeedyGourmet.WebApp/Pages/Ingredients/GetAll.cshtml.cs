using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class GetAll : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public GetAll(IService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public List<Ingredient> Ingredients { get; private set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Ingredients = _ingredientService.GetAll();
        }

        public void OnPost()
        {
            string ingredientName = Convert.ToString(Request.Form["name"]);
            _ingredientService.Create( new Ingredient { Name = ingredientName });
            OnGet();
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
