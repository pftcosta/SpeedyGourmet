using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class UserRepository : IRepository<User, int>
    {
        private readonly string _tableName = "users";
        public User Create(User user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string sql = $"INSERT INTO {_tableName} (username, password, name, email, is_admin, is_blocked) VALUES " +
                $"('{user.UserName}', " +
                $"CONVERT(VARCHAR(32), HashBytes('MD5', '{user.Password}'), 2), " +
                $"'{user.Name}', " +
                $"'{user.Email}', " +
                $"{isAdmin}, " +
                $"{isBlocked});";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", _tableName);
            return GetById(maxId);
        }

        public User GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {id} not found.");
        }

        public List<User> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName} ORDER BY id ASC;";
            SqlDataReader reader = SQL.Execute(sql);
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(Parse(reader));
            }
            return users;
        }

        public User Parse(SqlDataReader reader)
        {
            User user = new User();
            user.Id = Convert.ToInt32(reader["id"]);
            user.UserName = Convert.ToString(reader["username"]);
            user.Password = Convert.ToString(reader["password"]);
            user.Name = Convert.ToString(reader["name"]);
            user.Email = Convert.ToString(reader["email"]);
            user.IsAdmin = Convert.ToBoolean(reader["is_admin"]);
            user.IsBlocked = Convert.ToBoolean(reader["is_blocked"]);

            return user;
        }

        public User Update(User user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string sql = $"UPDATE {_tableName} SET " +
                $"username = '{user.UserName}', " +
                $"password = CONVERT(VARCHAR(32), HashBytes('MD5', '{user.Password}'), 2)," +
                $"name = '{user.Name}', " +
                $"email = '{user.Email}', " +
                $"admin = {user.IsAdmin}, " +
                $"blocked = {user.IsBlocked} " +
                $"WHERE id = {user.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(user.Id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);

        }
    }
}
