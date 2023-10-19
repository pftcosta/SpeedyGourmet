using SpeedyGourmet.Model;

namespace SpeedyGourmet.Service
{
    // INTERFACE FOR CATEGORY, DIFFICULTY, INGREDIENT, MEASURE, RECIPE and USER
    public interface IService<T, PK> 
    {
        T Create(T type);
        T GetById(PK id);
        List<T> GetAll();
        T Update(T type);
        void Delete(PK id);
    }
}
