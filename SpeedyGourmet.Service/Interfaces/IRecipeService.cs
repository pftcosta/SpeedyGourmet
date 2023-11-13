using SpeedyGourmet.Model;

namespace SpeedyGourmet.Service
{
    public interface IRecipeService
    {
        Recipe Create(Recipe recipe);
        Recipe GetById(int recipeId);
        List<Recipe> GetAll();
        List<Recipe> GetAllByUserId(int userId);
        Recipe Update(Recipe recipe);
        void Delete(int recipeId);
        void DeleteAllByUserId(int userId);
    }
}
