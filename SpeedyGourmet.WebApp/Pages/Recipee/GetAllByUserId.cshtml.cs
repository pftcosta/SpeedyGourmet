using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetAllByUserIdModel : PageModel
    {
        private readonly IRecipeService<Recipe, int> _recipeService;
        private readonly IService<User, int> _userService;

        public GetAllByUserIdModel(IRecipeService<Recipe, int> recipeService, IService<User, int> userService)
        {
            _recipeService = recipeService;
            _userService = userService;
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