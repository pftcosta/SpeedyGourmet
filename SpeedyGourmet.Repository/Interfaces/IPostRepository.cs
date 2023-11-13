using SpeedyGourmet.Model;

namespace SpeedyGourmet.Repository
{
    public interface IPostRepository
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
    }
}
