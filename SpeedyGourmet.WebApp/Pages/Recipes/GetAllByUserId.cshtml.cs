using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetAllByUserId : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;

        public GetAllByUserId(IRecipeService recipeService, IUserService userService)
        {
            _recipeService = recipeService;
            _userService = userService;
        }

        public List<Recipe> Recipes { get; private set; }
        public List<User> Users { get; private set; }
        public User User { get; set; }

        public void OnGet(int userId)
        {
            GetUser();
            Recipes = _recipeService.GetAllByUserId(userId);
            Users = _userService.GetAll();
        }

        public void OnPost()
        {
            int userId = Convert.ToInt32(Request.Form["id_user"]);
            OnGet(userId);
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