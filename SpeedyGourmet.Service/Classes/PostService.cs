using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class PostService : IILPostService<Post, int>
    {
        private readonly IILPostRepository<Post, int> _postRepository;
        private readonly IService<User, int> _userService;
        private readonly IRecFavService<Recipe, int> _recipeService;

        public PostService(IILPostRepository<Post, int> postRepositor, IService<User, int> userService, IRecFavService<Recipe, int> recipeService)
        {
            _postRepository = postRepositor;
            _userService = userService;
            _recipeService = recipeService;
        }

        public Post Create(Post post)
        {
            return _postRepository.Create(post);
        }

        public Post GetById(int id)
        {
            Post post = _postRepository.GetById(id);
            post.User = _userService.GetById(post.User.Id);
            post.Recipe = _recipeService.GetById(post.Recipe.Id);

            return post;
        }

        public List<Post> GetAll()
        {
            List<Post> posts = _postRepository.GetAll();
            foreach (Post post in posts)
            {
                post.User = _userService.GetById(post.User.Id);
                post.Recipe = _recipeService.GetById(post.Recipe.Id);
            }
            return posts;
        }

        public List<Post> GetAllByRecipeId(int recipeId)
        {
            List<Post> posts = _postRepository.GetAllByRecipeId(recipeId);
            foreach (Post post in posts)
            {
                post.User = _userService.GetById(post.User.Id);
                post.Recipe = _recipeService.GetById(post.Recipe.Id);
            }
            return posts;
        }
        public List<Post> GetAllByUserId(int userId)
        {
            List<Post> posts = _postRepository.GetAllByUserId(userId);
            foreach (Post post in posts)
            {
                post.User = _userService.GetById(post.User.Id);
                post.Recipe = _recipeService.GetById(post.Recipe.Id);
            }
            return posts;
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            _postRepository.DeleteAllByRecipeId(recipeId);
        }

        
        public void DeleteAllByUserId(int userId)
        {
            _postRepository.DeleteAllByUserId(userId);
        }
    }
}
