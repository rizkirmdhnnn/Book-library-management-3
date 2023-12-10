using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_library_member.Models.entity;
using book_library_member.Models.context;
using System.Collections;

namespace book_library_member.Models.repository
{
    public class usersRepository
    {
        private SQLiteConnection _connection;

        public usersRepository(DbContext context)
        {
            _connection = context.Conn;
        }

        public string checkUser(users users)
        {
            string result = "";
            string sql = @"SELECT username, password FROM users WHERE username = @username AND password = @password AND status = 'user'";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@username", users.username);
                cmd.Parameters.AddWithValue("@password", users.password);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) result = reader["username"].ToString();
                    else System.Diagnostics.Debug.Print("Username Not Found");
                }
            }
            return result;
        }

    }
}
