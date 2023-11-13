using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class IngredientService : IService<Ingredient, int>
    {
        private readonly IRepository<Ingredient, int> _ingredientRepository;

        public IngredientService(IRepository<Ingredient, int> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Ingredient Create(Ingredient ingredient)
        {
            return _ingredientRepository.Create(ingredient);
        }

        public Ingredient GetById(int ingredientId)
        {
            return _ingredientRepository.GetById(ingredientId);
        }

        public List<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _ingredientRepository.Update(ingredient);
        }

        public void Delete(int ingredientId)
        {
            _ingredientRepository.Delete(ingredientId);
        }
    }
}