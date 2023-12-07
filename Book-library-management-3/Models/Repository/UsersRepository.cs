using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Models.Context;
using Book_library_management_3.Views;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;


namespace Book_library_management_3.Models.Repository
{
    public class usersRepository
    {
        private SQLiteConnection _connection;

        public usersRepository(DbContext context)
        {
            _connection = context.Conn;
        }

        public int addUser(Users users)
        {
            int result = 0;

            string sql = @"insert into users (username, password, name, email, status, date_register) values  (@username, @password, @name, @email, @status, @date_register)";
            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@username", users.username);
                command.Parameters.AddWithValue("@password", users.password);
                command.Parameters.AddWithValue("@name", users.name);
                command.Parameters.AddWithValue("@email", users.email);
                command.Parameters.AddWithValue("@status", users.status);
                command.Parameters.AddWithValue("@date_register", users.date_register);

                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error : {0}", ex.Message);
                }
            }

            return result;
        }

        public int deleteUser(Users users)
        {
            int result = 0;

            string sql = @"DELETE FROM users WHERE username = @username";

            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@username", users.username);

                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error : {0}", ex.Message);
                }
            }
            return result;
        }

        public int updateUser(Users users)
        {
            int result = 0;

            string sql = @"UPDATE users SET username = @username, password = @password, name = @name, email = @email, status = @status, date_register = @date WHERE username = @username";
            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@username", users.username);
                command.Parameters.AddWithValue("@password", users.password);
                command.Parameters.AddWithValue("@name", users.name);
                command.Parameters.AddWithValue("@email", users.email);
                command.Parameters.AddWithValue("@status", users.status);
                command.Parameters.AddWithValue("@date", users.date_register);

                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("SQLite Error: {0}. Query: {1}", ex.Message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error : {0}", ex.Message);
                }
            }


            return result;
        }

        public string checkUserAdmin(Users users)
        {
            string result = "";
            string query = "SELECT * FROM users WHERE username = @username AND password = @password AND status = 'admin'";
            using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@username", users.username);
                cmd.Parameters.AddWithValue("@password", users.password);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) result = reader["name"].ToString();
                    else System.Diagnostics.Debug.Print("Username Not Found");
                }
            }
            return result;
        }

        public List<Users> getUser()
        {
            List<Users> list = new List<Users>();
            try
            {
                string sql = @"select * from users ";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Users user = new Users();
                            user.username = dtr["username"].ToString();
                            user.password = dtr["password"].ToString();
                            user.name = dtr["name"].ToString();
                            user.email = dtr["email"].ToString();
                            user.status = dtr["status"].ToString();
                            user.date_register = dtr["date_register"].ToString();
                            list.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getAllTransactions error: {0}", ex.Message);
            }
            return list;


        }
        public List<Users> getUserAdmin()
        {
            List<Users> list = new List<Users>();
            try
            {
                string sql = @"select * from users where status='admin'";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Users user = new Users();
                            user.username = dtr["username"].ToString();
                            user.password = dtr["password"].ToString();
                            user.name = dtr["name"].ToString();
                            user.email = dtr["email"].ToString();
                            user.date_register = dtr["date_register"].ToString();
                            list.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getAllTransactions error: {0}", ex.Message);
            }
            return list;


        }

        public int getTotalMembers()
        {

            int result = 0;

            string sql = @"SELECT COUNT(*) FROM users WHERE status = 'user'";

            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {

                try
                {
                    result = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: {0}. Query: {1}", ex.Message, command);

                }
            }
            return result;

        }
        public int getTotalAdmin()
        {

            int result = 0;

            string sql = @"SELECT COUNT(*) FROM users WHERE status = 'admin'";

            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {

                try
                {
                    result = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: {0}. Query: {1}", ex.Message, command);

                }
            }
            return result;

        }

        public List<Users> getByUsername(Users users)
        {
            List<Users> list = new List<Users>();
            try
            {
                string sql = @"SELECT * FROM users WHERE username LIKE @username";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@username", "%" + users.username + "%");
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Users user = new Users();
                            user.username = dtr["username"].ToString();
                            user.password = dtr["password"].ToString();
                            user.name = dtr["name"].ToString();
                            user.email = dtr["email"].ToString();
                            user.status = dtr["status"].ToString();
                            user.date_register = dtr["date_register"].ToString();
                            list.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getAllTransactions error: {0}", ex.Message);
            }
            return list;


        }

        public List<Users> getRecentMembers()
        {

            List<Users> list = new List<Users>();
            try
            {
                string sql = @"SELECT username, status FROM ( SELECT username, status, ROW_NUMBER() OVER () AS row_num FROM users) AS user_with_rownum WHERE user_with_rownum.row_num > (SELECT COUNT(*) FROM users) - 7";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Users user = new Users();
                            user.username = dtr["username"].ToString();
                            user.status = dtr["status"].ToString();
                            list.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getRecentMembers error: {0}", ex.Message);
            }
            return list;

        }

        public AutoCompleteStringCollection getUsername()
        {
            string sql = @"SELECT username from users";
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
            {
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        autoComplete.Add(dtr.GetString(0));
                    }
                }

            }
            return autoComplete;

        }

        public string getEmailByUsername(string name)
        {
            string result = "";
            string query = "SELECT email FROM users WHERE name = @name";
            using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@name", name);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) result = reader.GetString(0);
                }
            }
            return result;
        }
    }
}
