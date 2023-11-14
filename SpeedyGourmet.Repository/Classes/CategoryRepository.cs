using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly string _tableName = "categories";

        public Category Create(Category category)
        {
            string sql =$"INSERT INTO {_tableName} (name) VALUES ('{category.Name}');";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", _tableName);
            return GetById(maxId);
        }

        public Category GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {id} not found.");
        }
        
        public List<Category> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Category> categories = new List<Category>();

            while (reader.Read())
            {
                categories.Add(Parse(reader));
            }
            return categories;
        }
      
        public Category Update(Category category)
        {
            string sql = $"UPDATE {_tableName} SET name = '{category.Name}' WHERE id = {category.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(category.Id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        private Category Parse(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id"]);
            category.Name = Convert.ToString(reader["name"]);
            return category;
        }
    }
}
