using SpeedyGourmet.Model;

namespace SpeedyGourmet.Service
{
    public interface IIngredientLineService
    {
        IngredientLine Create(IngredientLine ingredientLine);
        IngredientLine GetById(int ingredientLineId);
        List<IngredientLine> GetAll();
        List<IngredientLine> GetAllByRecipeId(int recipeId);
        void Delete(int ingredientLineId);
        void DeleteAllByRecipeId(int recipeId);
    }
}
