using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;

namespace SpeedyGourmet.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        public PostService(IPostRepository postRepository, IUserService userService, IRecipeService recipeService)
        {
            _postRepository = postRepository;
            _userService = userService;
            _recipeService = recipeService;
        }

        public Post Create(Post post)
        {
            return _postRepository.Create(post);
        }

        public Post GetById(int postId)
        {
            Post post = _postRepository.GetById(postId);
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
                post.Recipe.Author = _userService.GetById(post.Recipe.Author.Id);
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
        public Post Update(Post post)
        {
            return _postRepository.Update(post);
        }

        public void Delete(int postId)
        {
            _postRepository.Delete(postId);
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
