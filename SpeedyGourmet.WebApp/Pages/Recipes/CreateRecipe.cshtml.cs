using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class CreateRecipe : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IService<Measure, int> _measureService;
        private readonly IService<User, int> _userService;

        public CreateRecipe(IRecipeService recipeService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IService<Measure, int> measureService, IService<User, int> userService, List<Category> categories, List<Difficulty> difficulties, List<Recipe> recipes, List<Measure> measures, List<User> users)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _measureService = measureService;
            _userService = userService;
            Categories = categories;
            Difficulties = difficulties;
            Recipes = recipes;
            Measures = measures;
            Users = users;
        }

        public List<Category> Categories { get; set; }
        public List<Difficulty> Difficulties { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Measure> Measures { get; set; }
        public List<User> Users { get; set; }

    public void OnGet()
        {
            Recipes = _recipeService.GetAll();
            Categories = _categoryService.GetAll();
            Difficulties = _difficultyService.GetAll();
            Measures = _measureService.GetAll();
            Users = _userService.GetAll();
        }

        public IActionResult OnPost()
        {
            Recipe recipe = new();

            recipe.Title = Convert.ToString(Request.Form["title"]);
            recipe.PrepTime = Convert.ToInt32(Request.Form["prep_time"]);
            recipe.PrepMethod = Convert.ToString(Request.Form["prep_method"]);

            recipe.Author = new User();
            recipe.Author.Id = Convert.ToInt32(Request.Form["id_user"]);

            recipe.Category = new Category();
            recipe.Category.Id = Convert.ToInt32(Request.Form["id_category"]);

            recipe.Difficulty = new Difficulty();
            recipe.Difficulty.Id = Convert.ToInt32(Request.Form["id_difficulty"]);

            recipe = _recipeService.Create(recipe);

            return RedirectToPage("/Recipes/AddIngredients", new { id = recipe.Id });
        }
    }
}
