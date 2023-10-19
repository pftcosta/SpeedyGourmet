using SpeedyGourmet.Model;

namespace SpeedyGourmet.Service
{
    // INTERFACE FOR FAVOURITE
    public interface IFavouriteService 
    {
        Favourite Create(Favourite favourite);
        Favourite GetById(int id);
        List<Favourite> GetAll();
        List<Favourite> GetAllByUserId();
        void Delete(int id);
        void DeleteAllByUserId(int userId);
    }
}
