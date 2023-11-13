using SpeedyGourmet.Model;

namespace SpeedyGourmet.Repository
{
    public interface IFavouriteRepository
    {
        Favourite Create(Favourite favourite);
        Favourite GetById(int favouriteId);
        List<Favourite> GetAll();
        List<Favourite> GetAllByUserId(int userId);
        void Delete(int favouriteId);
        void DeleteAllByUserId(int userId);
    }
}
