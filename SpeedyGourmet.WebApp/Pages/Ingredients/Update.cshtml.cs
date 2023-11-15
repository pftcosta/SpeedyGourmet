using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Ingredients
{
    public class Update : PageModel
    {
        private readonly IService<Ingredient, int> _ingredientService;

        public Update(IService<Ingredient, int> ingredientService)
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

        public IActionResult OnPost()
        {
            Ingredient = new Ingredient()
            {
                Id = Convert.ToInt32(Request.Form["id"]),
                Name = Convert.ToString(Request.Form["name"])
            };
            
            _ingredientService.Update(Ingredient);
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
