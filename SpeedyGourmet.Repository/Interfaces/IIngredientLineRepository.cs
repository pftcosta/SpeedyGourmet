using SpeedyGourmet.Model;

namespace SpeedyGourmet.Repository
{
    public interface IIngredientLineRepository
    {
        IngredientLine Create(IngredientLine ingredientLine);
        IngredientLine GetById(int ingredientLineId);
        List<IngredientLine> GetAll();
        List<IngredientLine> GetAllByRecipeId(int recipeId);
        void Delete(int ingredientLineId);
        void DeleteAllByRecipeId(int recipeId);
    }
}
