using SpeedyGourmet.Model;

namespace SpeedyGourmet.Service
{
    public interface IPostService
    {
        Post Create(Post post);
        Post GetById(int postId);
        List<Post> GetAll();
        List<Post> GetAllByRecipeId(int recipeId);
        List<Post> GetAllByUserId(int recipeId);
        Post Update(Post post);
        void Delete(int postId);
        void DeleteAllByRecipeId(int recipeId);
        void DeleteAllByUserId(int userId);
        List<Post> Search(string query);
    }
}
