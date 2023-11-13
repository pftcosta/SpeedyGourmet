using SpeedyGourmet.Model;

namespace SpeedyGourmet.Repository
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetById(int userId);
        List<User> GetAll();
        User Update(User user);
        void Delete(int userId);
        User LogIn(string username, string password);
    }
}
