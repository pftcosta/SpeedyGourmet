using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }

        public User LogIn(string username, string password)
        {
            return _userRepository.LogIn(username, password);
        }
    }
}
