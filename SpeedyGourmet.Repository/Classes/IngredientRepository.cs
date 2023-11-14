using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class IngredientRepository : IRepository<Ingredient, int>
    {
        private readonly string _tableName = "ingredients";

        public Ingredient Create(Ingredient ingredient)
        {
            string sql = $"INSERT INTO {_tableName} (name) VALUES ('{ingredient.Name}');";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", _tableName);
            return GetById(maxId);
        }
        
        public Ingredient GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {id} not found.");
        }

        public List<Ingredient> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Ingredient> ingredients = new List<Ingredient>();

            while (reader.Read())
            {
                ingredients.Add(Parse(reader));
            }
            return ingredients;
        }

        public Ingredient Update(Ingredient ingredient)
        {
            string sql = $"UPDATE {_tableName} SET name = '{ingredient.Name}' WHERE id = {ingredient.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(ingredient.Id);
        }
        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        private Ingredient Parse(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id"]);
            ingredient.Name = Convert.ToString(reader["name"]);
            return ingredient;
        }

    }
}