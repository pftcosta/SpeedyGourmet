using SpeedyGourmet.Model;

namespace SpeedyGourmet.Service
{
    // INTERFACE FOR RECIPE AND FAVOURITE
    public interface IRecFavService<T, PK>
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
