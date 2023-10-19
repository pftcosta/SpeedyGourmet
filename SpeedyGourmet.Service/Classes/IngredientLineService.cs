using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class IngredientLineService : IILPostService<IngredientLine, int>
    {
        private readonly IILPostRepository<IngredientLine, int> _ingredientLineRepository;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;

        public IngredientLineService(IILPostRepository<IngredientLine, int> ingredientLineRepository, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService)
        {
            _ingredientLineRepository = ingredientLineRepository;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public IngredientLine Create(IngredientLine ingredientLine)
        {
            return _ingredientLineRepository.Create(ingredientLine);
        }

        public IngredientLine GetById(int id)
        {
            IngredientLine ingredientLine = _ingredientLineRepository.GetById(id);
            ingredientLine.Ingredient = _ingredientService.GetById(ingredientLine.Ingredient.Id);
            ingredientLine.Measure = _measureService.GetById(ingredientLine.Measure.Id);
            return ingredientLine;
        }

        public List<IngredientLine> GetAll()
        {
            List<IngredientLine> ingredientLines = _ingredientLineRepository.GetAll();
            //foreach (IngredientLine ingredientLine in ingredientLines)
            //{
            //    ingredientLine.Ingredient = _ingredientService.GetById(ingredientLine.Ingredient.Id);
            //    ingredientLine.Measure = _measureService.GetById(ingredientLine.Measure.Id);
            //}
            return ingredientLines;
        }

        public List<IngredientLine> GetAllByRecipeId(int recipeId)
        {
            List<IngredientLine> ingredientLines = _ingredientLineRepository.GetAllByRecipeId(recipeId);
            foreach (IngredientLine ingredientLine in ingredientLines)
            {
                ingredientLine.Ingredient = _ingredientService.GetById(ingredientLine.Ingredient.Id);
                ingredientLine.Measure = _measureService.GetById(ingredientLine.Measure.Id);
            }
            return ingredientLines;
        }

        public void Delete(int id)
        {
            _ingredientLineRepository.Delete(id);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            _ingredientLineRepository.DeleteAllByRecipeId(recipeId);
        }
    }
}
