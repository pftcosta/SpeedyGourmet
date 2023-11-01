using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class RecipeService : IRecFavService<Recipe, int>
    {
        private readonly IRecFavRepository<Recipe, int> _recipeRepository;
        private readonly IService<User, int> _userService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IILPostService<IngredientLine, int> _ingredientLineService;

        public RecipeService(IRecFavRepository<Recipe, int> recipeRepository, IService<User, int> userService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IILPostService<IngredientLine, int> ingredientLineService)
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

        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }

        public void DeleteAllByUserId(int userId)
        {
            _recipeRepository.DeleteAllByUserId(userId);
        }

        public Recipe Update(Recipe recipe)
        {
            return _recipeRepository.Update(recipe);
        }
    }
}
