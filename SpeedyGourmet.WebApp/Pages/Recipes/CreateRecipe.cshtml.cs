using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Recipes
{
    public class CreateRecipe : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IService<Measure, int> _measureService;
        private readonly IService<User, int> _userService;

        public CreateRecipe(IRecipeService recipeService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IService<Measure, int> measureService, IService<User, int> userService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _measureService = measureService;
            _userService = userService;
        }

        public List<Category> Categories { get; private set; }
        public List<Difficulty> Difficulties { get; private set; }
        public List<Recipe> Recipes { get; private set; }
        public List<User> Users { get; private set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Recipes = _recipeService.GetAll();
            Categories = _categoryService.GetAll();
            Difficulties = _difficultyService.GetAll();
            Users = _userService.GetAll();
        }

        public IActionResult OnPost()
        {
            Recipe recipe = new Recipe()
            {
                IsApproved = false,
                Title = Convert.ToString(Request.Form["title"]),
                PrepTime = Convert.ToInt32(Request.Form["prep_time"]),
                PrepMethod = Convert.ToString(Request.Form["prep_method"]),
                Author = new User { Id = Convert.ToInt32(Request.Form["id_user"]) },
                Category = new Category { Id = Convert.ToInt32(Request.Form["id_category"]) },
                Difficulty = new Difficulty { Id = Convert.ToInt32(Request.Form["id_difficulty"]) }
            };

            recipe = _recipeService.Create(recipe);
            return RedirectToPage("/Recipes/AddIngredients", new { id = recipe.Id });
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
