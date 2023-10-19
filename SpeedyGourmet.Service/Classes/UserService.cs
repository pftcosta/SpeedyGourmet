using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class UserService : IService<User, int>
    {
        private readonly IRepository<User, int> _userRepository;

        public UserService(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

    }
}
