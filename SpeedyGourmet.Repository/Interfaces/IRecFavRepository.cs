using SpeedyGourmet.Model;

namespace SpeedyGourmet.Repository
{
    public interface IRecFavRepository<T, PK> // interface for FAVOURITE
    {
        T Create(T Type);
        T GetById(PK id);
        List<T> GetAll();
        List<T> GetAllByUserId(PK id);
        void Delete(PK id);
        void DeleteAllByUserId(PK id);
        T Update(T Type);
    }
}
