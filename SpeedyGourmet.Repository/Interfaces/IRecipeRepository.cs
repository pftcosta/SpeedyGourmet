using SpeedyGourmet.Model;

namespace SpeedyGourmet.Repository
{
    public interface IRecipeRepository
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
