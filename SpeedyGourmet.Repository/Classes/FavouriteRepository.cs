using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class FavouriteRepository : IFavouriteRepository
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

        public Favourite GetById(int favouriteId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {favouriteId};";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {favouriteId} not found.");
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

        public void Delete(int favouriteId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {favouriteId};";
            SQL.ExecuteNonQuery(sql);
        }

        public void DeleteAllByUserId(int userId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id_user = {userId};";
            SQL.ExecuteNonQuery(sql);
        }

        private Favourite Parse(SqlDataReader reader)
        {
            Favourite favourite = new Favourite();
            favourite.Id = Convert.ToInt32(reader["id"]);

            favourite.User = new User();
            favourite.User.Id = Convert.ToInt32(reader["id_user"]);

            favourite.Recipe = new Recipe();
            favourite.Recipe.Id = Convert.ToInt32(reader["id_recipe"]);

            return favourite;
        }
    }
}
