using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Book_Library_Management_3.Models.Context;
using Book_library_management_3.Models.Entity;

namespace Book_Library_Management_3.Models.Repository
{
    public class BooksRepository
    {
        private SQLiteConnection _connection;

        public BooksRepository(DbContext context)
        {
            _connection = context.Conn;
        }

        public int addBook(Books books)
        {
            int result = 0;

            string sql = @"insert into books (isbn, title, writter, genre, publisher, stocks) values (@isbn, @title, @writter, @genre, @publisher, @stocks)";
            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@isbn", books.isbn);
                command.Parameters.AddWithValue("@title", books.title);
                command.Parameters.AddWithValue("@writter", books.writter);
                command.Parameters.AddWithValue("@genre", books.genre);
                command.Parameters.AddWithValue("@publisher", books.publisher);
                command.Parameters.AddWithValue("@stocks", books.stocks);

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

        public int updateBook(Books books)
        {
            int result = 0;

            string sql = @"";

            return result;

        }

        public int deleteBook(Books books)
        {
            int result = 0;

            string sql = @"";

            return result;
        }

    }
}
