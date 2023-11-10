using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetByIdModel : PageModel
    {
        private readonly IRecFavService<Recipe, int> _recipeService;
        private readonly IService<User, int> _userService;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;
        private readonly IILPostService<IngredientLine, int> _ingredientLineService;
        private readonly IILPostService<Post, int> _postService;

        public GetByIdModel(IRecFavService<Recipe, int> recipeService, IService<User, int> userService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService, IILPostService<IngredientLine, int> ingredientLineService, IILPostService<Post, int> postService)
        {
            _recipeService = recipeService;
            _userService = userService;
            _ingredientService = ingredientService;
            _measureService = measureService;
            _ingredientLineService = ingredientLineService;
            _postService = postService;
        }

        public Recipe Recipe { get; set; }
        public User User { get; set; }
        public List<Post> Posts { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<User> Users { get; set; }

        public void OnGet(int id)
        {
            Recipes = _recipeService.GetAllByUserId(id);
            Users = _userService.GetAll();
            User = _userService.GetById(id);
            Posts = _postService.GetAllByRecipeId(id);
            Recipe = _recipeService.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            Recipe = _recipeService.GetById(id);
            return RedirectToPage("/Recipee/AddIngredients", new { id = Recipe.Id });
        }
    }
}