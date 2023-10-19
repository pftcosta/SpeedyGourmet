namespace SpeedyGourmet.Repository
{
    public interface IILPostRepository<T, PK> // interface for INGREDIENTLINE and POST
    {
        T Create(T type);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAllByRecipeId(PK id);
        void Delete(PK id);
        void DeleteAllByRecipeId(PK id);
    }
}
