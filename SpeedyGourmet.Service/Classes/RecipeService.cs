using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserService _userService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IIngredientLineService _ingredientLineService;

        public RecipeService(IRecipeRepository recipeRepository, IUserService userService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IIngredientLineService ingredientLineService)
        {
            _recipeRepository = recipeRepository;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _ingredientLineService = ingredientLineService;
        }

        public Recipe Create(Recipe recipe)
        {
            return _recipeRepository.Create(recipe);
        }

        public Recipe GetById(int id)
        {
            Recipe recipe = _recipeRepository.GetById(id);
            recipe.Author = _userService.GetById(recipe.Author.Id);
            recipe.Ingredients = _ingredientLineService.GetAllByRecipeId(recipe.Id);
            recipe.Category = _categoryService.GetById(recipe.Category.Id);
            recipe.Difficulty = _difficultyService.GetById(recipe.Difficulty.Id);
            return recipe;
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> recipes = _recipeRepository.GetAll();
            foreach (Recipe recipe in recipes)
            {
                recipe.Author = _userService.GetById(recipe.Author.Id);
                recipe.Ingredients = _ingredientLineService.GetAllByRecipeId(recipe.Id);
                recipe.Category = _categoryService.GetById(recipe.Category.Id);
                recipe.Difficulty = _difficultyService.GetById(recipe.Difficulty.Id);
            }
            return recipes;
        }

        public List<Recipe> GetAllByUserId(int userId)
        {
            List<Recipe> recipes = _recipeRepository.GetAllByUserId(userId);
            foreach (Recipe recipe in recipes)
            {
                recipe.Author = _userService.GetById(recipe.Author.Id);
                recipe.Ingredients = _ingredientLineService.GetAllByRecipeId(recipe.Id);
                recipe.Category = _categoryService.GetById(recipe.Category.Id);
                recipe.Difficulty = _difficultyService.GetById(recipe.Difficulty.Id);
            }
            return recipes;
        }

        public Recipe Update(Recipe recipe)
        {
            return _recipeRepository.Update(recipe);
        }

        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }

        public void DeleteAllByUserId(int userId)
        {
            _recipeRepository.DeleteAllByUserId(userId);
        }
    }
}
