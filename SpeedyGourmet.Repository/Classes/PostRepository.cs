using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class PostRepository : IILPostRepository<Post, int>
    {
        private readonly string _tableName = "posts";
        public Post Create(Post post)
        {
            string sql = $"INSERT INTO {_tableName} (id_user, id_recipe, comment, rating) VALUES ({post.User.Id}, {post.Recipe.Id}, '{post.Comment}', {post.Rating});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", _tableName);
            return GetById(id);
        }

        public Post GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {id} not found.");
        }

        public List<Post> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Post> comments = new List<Post>();
            while (reader.Read())
            {
                comments.Add(Parse(reader));
            }
            return comments;
        }

        public List<Post> GetAllByRecipeId(int recipeId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id_recipe = {recipeId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Post> comments = new List<Post>();
            while (reader.Read())
            {
                comments.Add(Parse(reader));
            }
            return comments;
        }

        public List<Post> GetAllByUserId(int userId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id_user = {userId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Post> comments = new List<Post>();
            while (reader.Read())
            {
                comments.Add(Parse(reader));
            }
            return comments;
        }

        private Post Parse(SqlDataReader reader)
        {
            Post post = new Post();
            post.Id = Convert.ToInt32(reader["id"]);
            post.Comment = Convert.ToString(reader["comment"]);
            post.Rating = Convert.ToInt32(reader["rating"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_user"]);
            post.User = user;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            post.Recipe = recipe;

            return post;
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id_recipe = {recipeId};";
            SQL.ExecuteNonQuery(sql);
        }

        public void DeleteAllByUserId(int userId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id_user = {userId};";
            SQL.ExecuteNonQuery(sql);
        }
    }
}
