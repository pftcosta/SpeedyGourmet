using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class DifficultyRepository : IRepository<Difficulty, int>
    {
        private readonly string _tableName = "difficulties";

        public Difficulty Create(Difficulty difficulty)
        {
            string sql = $"INSERT INTO {_tableName} (name) VALUES ('{difficulty.Name}');";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", _tableName);
            return GetById(maxId);
        }

        public Difficulty GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {id} not found.");
        }

        public List<Difficulty> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName} ORDER BY id ASC;";
            SqlDataReader reader = SQL.Execute(sql);
            List<Difficulty> difficulties = new List<Difficulty>();
            while (reader.Read())
            {
                difficulties.Add(Parse(reader));
            }
            return difficulties;
        }

        public Difficulty Update(Difficulty difficulty)
        {
            string sql = $"UPDATE {_tableName} SET name = '{difficulty.Name}' WHERE id = {difficulty.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(difficulty.Id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Difficulty Parse(SqlDataReader reader)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id"]);
            difficulty.Name = Convert.ToString(reader["name"]);
            return difficulty;
        }
    }
}
