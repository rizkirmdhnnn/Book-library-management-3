using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_library_management_3.Models.Entity;
using Book_Library_Management_3.Models.Context;


namespace Book_Library_Management_3.Models.Repository
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
                command.Parameters.AddWithValue("@date_register", DateTime.Now);

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
    }
}
