namespace SpeedyGourmet.Repository
{
    public interface IRepository<T, PK> // interface for CATEGORY, DIFFICULTY, INGREDIENT, MEASURE, RECIPE and USER
    {
        T Create(T type);
        T GetById(PK id);
        List<T> GetAll();
        T Update(T type);
        void Delete(PK id);
    }
}
