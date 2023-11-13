namespace SpeedyGourmet.Repository
{
    // interface for CATEGORY, DIFFICULTY, INGREDIENT, MEASURE and RECIPE
    public interface IRepository<T, PK> 
    {
        T Create(T type);
        T GetById(PK id);
        List<T> GetAll();
        T Update(T type);
        void Delete(PK id);
    }
}
