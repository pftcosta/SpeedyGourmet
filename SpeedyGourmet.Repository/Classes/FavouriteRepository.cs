using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class FavouriteRepository : IRecFavRepository<Favourite, int>
    {
        private readonly string _tableName = "favourites";

        public Favourite Create(Favourite favourite)
        {
            string sql = $"INSERT INTO {_tableName} (id_user, id_recipe) VALUES " +
                $"({favourite.User.Id}, " +
                $"{favourite.Recipe.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", _tableName);
            return GetById(id);
        }

        public Favourite GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {id} not found.");
        }

        public List<Favourite> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Favourite> favourites = new List<Favourite>();
            while (reader.Read())
            {
                favourites.Add(Parse(reader));
            }
            return favourites;
        }

        public List<Favourite> GetAllByUserId(int userId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id_user = {userId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Favourite> favourites = new List<Favourite>();
            while (reader.Read())
            {
                favourites.Add(Parse(reader));
            }
            return favourites;
        }

        private Favourite Parse(SqlDataReader reader)
        {
            Favourite favourite = new Favourite();
            favourite.Id = Convert.ToInt32(reader["id"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_user"]);
            favourite.User = user;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            favourite.Recipe = recipe;

            return favourite;
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public void DeleteAllByUserId(int userId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id_user = {userId};";
            SQL.ExecuteNonQuery(sql);
        }

        public Favourite Update(Favourite Type)
        {
            throw new NotImplementedException();
        }
    }
}
