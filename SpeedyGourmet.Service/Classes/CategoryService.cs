using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class CategoryService : IService<Category, int>
    {
        private readonly IRepository<Category, int> _categoryRepository;

        public CategoryService(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Create(Category category)
        {
            return _categoryRepository.Create(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryRepository.GetById(categoryId);
        }

        public Category Update(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public void Delete(int categoryId)
        {
            _categoryRepository.Delete(categoryId);
        }
    }
}
