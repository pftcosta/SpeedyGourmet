using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        public FavouriteService(IFavouriteRepository favouriteRepository, IUserService userService, IRecipeService recipeService)
        {
            _favouriteRepository = favouriteRepository;
            _userService = userService;
            _recipeService = recipeService;
        }

        public Favourite Create(Favourite favourite)
        {
            return _favouriteRepository.Create(favourite);
        }

        public Favourite GetById(int favouriteId)
        {
            Favourite favourite = _favouriteRepository.GetById(favouriteId);
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

        public void Delete(int favouriteId)
        {
            _favouriteRepository.Delete(favouriteId);
        }

        public void DeleteAllByUserId(int userId)
        {
            _favouriteRepository.DeleteAllByUserId(userId);
        }
    }
}
