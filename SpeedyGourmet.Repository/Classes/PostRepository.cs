﻿using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly string _tableName = "posts";
        private readonly string _tableNameRecipes = "recipes";

        public Post Create(Post post)
        {
            string sql = $"INSERT INTO {_tableName} (id_user, id_recipe, comment, rating) VALUES" +
                $" ({post.User.Id}, " +
                $"{post.Recipe.Id}, " +
                $"'{post.Comment}', " +
                $"{post.Rating});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", _tableName);
            return GetById(id);
        }

        public Post GetById(int postId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {postId};";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {postId} not found.");
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
        public Post Update(Post post)
        {
            string sql = $"UPDATE {_tableName} SET " +
                $"id_user = {post.User.Id}, " +
                $"id_recipe = {post.Recipe.Id}," +
                $"comment = '{post.Comment}', " +
                $"rating = {post.Rating} " +
                $"WHERE id = {post.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(post.Id);
        }

        public void Delete(int postId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {postId};";
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

        private Post Parse(SqlDataReader reader)
        {
            Post post = new Post()
            {
                Id = Convert.ToInt32(reader["id"]),
                Comment = Convert.ToString(reader["comment"]),
                Rating = Convert.ToInt32(reader["rating"]),
                User = new User { Id = Convert.ToInt32(reader["id_user"]) },
                Recipe = new Recipe { Id = Convert.ToInt32(reader["id_recipe"]) }
            };
            return post;
        }

        public List<Post> Search(string query)
        {
            string sqlQuery = $@"SELECT *
                                FROM {_tableName}
                                WHERE id LIKE '%query%'
                                OR id_user LIKE '%query%'
                                OR id_recipe LIKE '%query%'
                                OR comment LIKE '%query%'
                                OR rating LIKE '%query%';";

            SqlDataReader reader = SQL.Execute(sqlQuery);
            List<Post> results = new List<Post>();

            while (reader.Read())
            {
                results.Add(Parse(reader));
            }
            return results;
        }

    }
}
