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

        public Ingredient GetById(int id)
        {
            return _ingredientRepository.GetById(id);
        }

        public List<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _ingredientRepository.Update(ingredient);
        }

        public void Delete(int id)
        {
            _ingredientRepository.Delete(id);
        }
    }
}