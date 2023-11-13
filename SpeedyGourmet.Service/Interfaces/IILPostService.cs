namespace SpeedyGourmet.Service
{
    // INTERFACE FOR INGREDIENTLINE AND POST
    public interface IILPostService<T, PK> 
    {
        T Create(T type);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAllByRecipeId(PK id);
        List<T> GetAllByUserId(PK id);
        void Delete(PK id);
        void DeleteAllByRecipeId(PK id);
        void DeleteAllByUserId(PK id);
    }
}
