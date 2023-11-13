using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetAllByUserId : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;

        public GetAllByUserId(IRecipeService recipeService, IUserService userService, List<Recipe> recipes, List<User> users)
        {
            _recipeService = recipeService;
            _userService = userService;
            Recipes = recipes;
            Users = users;
        }

        public List<Recipe> Recipes { get; set; }
        public List<User> Users { get; set; }

        public void OnGet(int id)
        {
            Recipes = _recipeService.GetAllByUserId(id);
            Users = _userService.GetAll();
        }

        public void OnPost()
        {
            Recipe recipe = new();
            recipe.User = new User();
            recipe.User.Id = Convert.ToInt32(Request.Form["id_user"]);

            OnGet(recipe.User.Id);
        }
    }
}