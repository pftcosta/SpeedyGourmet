using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class FavouriteService : IRecFavService<Favourite, int>
    {
        private readonly IRecFavRepository<Favourite, int> _favouriteRepository;
        private readonly IService<User, int> _userService;
        private readonly IRecFavService<Recipe, int> _recipeService;

        public FavouriteService(IRecFavRepository<Favourite, int> favouriteRepository, IService<User, int> userService, IRecFavService<Recipe, int> recipeService)
        {
            _favouriteRepository = favouriteRepository;
            _userService = userService;
            _recipeService = recipeService;
        }

        public Favourite Create(Favourite favourite)
        {
            return _favouriteRepository.Create(favourite);
        }

        public Favourite GetById(int id)
        {
            Favourite favourite = _favouriteRepository.GetById(id);
            favourite.User = _userService.GetById(favourite.User.Id);
            favourite.Recipe = _recipeService.GetById(favourite.Recipe.Id);

            return favourite;
        }

        public List<Favourite> GetAll()
        {

            List<Favourite> favourites = _favouriteRepository.GetAll();
            foreach (Favourite favourite in favourites)
            {
                favourite.User = _userService.GetById(favourite.User.Id);
                favourite.Recipe = _recipeService.GetById(favourite.Recipe.Id);
            }
            return favourites;
        }

        public List<Favourite> GetAllByUserId(int userId)
        {
            List<Favourite> favourites = _favouriteRepository.GetAllByUserId(userId);
            foreach (Favourite favourite in favourites)
            {
                favourite.User = _userService.GetById(favourite.User.Id);
                favourite.Recipe = _recipeService.GetById(favourite.Recipe.Id);
            }
            return favourites;
        }

        public void Delete(int id)
        {
            _favouriteRepository.Delete(id);
        }

        public void DeleteAllByUserId(int userId)
        {
            _favouriteRepository.DeleteAllByUserId(userId);
        }

        public Favourite Update(Favourite Type)
        {
            throw new NotImplementedException();
        }
    }
}
