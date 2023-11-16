using SpeedyGourmet.Model;
using System.Data.SqlClient;

namespace SpeedyGourmet.Repository
{
    public class UserRepository : IUserRepository
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
                $"'{user.IsAdmin}', " +
                $"'{user.IsBlocked}');";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", _tableName);
            return GetById(maxId);
        }

        public User GetById(int userId)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {userId};";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception($"{_tableName} Id: {userId} not found.");
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

        public User Update(User user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string sql = $"UPDATE {_tableName} SET " +
                $"username = '{user.UserName}', " +
                $"password = CONVERT(VARCHAR(32), HashBytes('MD5', '{user.Password}'), 2)," +
                $"name = '{user.Name}', " +
                $"email = '{user.Email}', " +
                $"is_admin = '{user.IsAdmin}', " +
                $"is_blocked = '{user.IsBlocked}' " +
                $"WHERE id = {user.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(user.Id);
        }

        public void Delete(int userId)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {userId};";
            SQL.ExecuteNonQuery(sql);

        }

        public User LogIn(string username, string password)
        {
            string sql = $@"SELECT * FROM {_tableName} WHERE username = '{username}'
                           AND password = CONVERT(VARCHAR(32), HashBytes('MD5', '{password}'), 2);";
            //string sql = $@"SELECT * FROM {_tableName} WHERE username = '{username}'
            //                AND password = '{password}'";
            SqlDataReader reader = SQL.Execute(sql);

            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("User not found.");
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
    }
}
