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

        public int checkUserAdmin(Users users)
        {
            int result = 0;
            string query = "SELECT * FROM users WHERE username = @username AND password = @password AND status = 'admin'";
            using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@username", users.username);
                cmd.Parameters.AddWithValue("@password", users.password);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) result = 1;
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
                string sql = @"select * from users where status='user'";

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
    }
}
