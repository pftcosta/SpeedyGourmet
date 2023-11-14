using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class MeasureRepository : IRepository<Measure, int>
    {
        private readonly string _tableName = "measures";

        public Measure Create(Measure measure)
        {
            string sql = $"INSERT INTO {_tableName} (name) VALUES ('{measure.Name}');";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", _tableName);
            return GetById(maxId);
        }

        public Measure GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {id} not found.");
        }

        public List<Measure> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Measure> measures = new List<Measure>();

            while (reader.Read())
            {
                measures.Add(Parse(reader));
            }
            return measures;
        }

        public Measure Update(Measure measure)
        {
            string sql = $"UPDATE {_tableName} SET name = '{measure.Name}' WHERE id = {measure.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(measure.Id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Measure Parse(SqlDataReader reader)
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(reader["id"]);
            measure.Name = Convert.ToString(reader["name"]);
            return measure;
        }
    }
}
