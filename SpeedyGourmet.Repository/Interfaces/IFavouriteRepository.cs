using SpeedyGourmet.Model;

namespace SpeedyGourmet.Repository
{
    public interface IFavouriteRepository // interface for FAVOURITE
    {
        Favourite Create(Favourite favourite);
        Favourite GetById(int id);
        List<Favourite> GetAll();
        List<Favourite> GetAllByUserId(int userId);
        void Delete(int id);
        void DeleteAllByUserId(int userId);
    }
}
