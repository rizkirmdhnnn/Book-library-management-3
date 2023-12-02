using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Book_library_management_3.Models.Context;
using Book_library_management_3.Models.Entity;
using System.Windows.Forms;

namespace Book_library_management_3.Models.Repository
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

        public int updateStocksBooks(Books books, string IncreseOrDecrease)
        {
            int result = 0;
            string sqlUpdateBook = "";

            if (IncreseOrDecrease == "+")
            {
                sqlUpdateBook = @"UPDATE books SET stock = stock + 1 WHERE isbn = @isbn";
            }
            
            if (IncreseOrDecrease == "-")
            {
                sqlUpdateBook = @"UPDATE books SET stock = stock - 1 WHERE isbn = @isbn";
            }

            using (SQLiteCommand updateCommand = new SQLiteCommand(sqlUpdateBook, _connection))
            {
                updateCommand.Parameters.AddWithValue("@isbn", books.isbn);

                try
                {
                    result = updateCommand.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    System.Diagnostics.Debug.Print("SQLite Error: {0}", ex.Message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: {0}", ex.Message);
                }
            }

            return result;
        }


        public int deleteBook(Books books)
        {
            int result = 0;

            string sql = @"DELETE FROM books WHERE isbn = @isbn";

            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@isbn", books.isbn);

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

        public int getTotalBook() { 
            
            int result = 0;

            string sql = @"SELECT COUNT(*) FROM books";

            using (SQLiteCommand command = new SQLiteCommand( sql, _connection))
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

        public List<Books> getRecentBooks()
        {
            List<Books> list = new List<Books>();
            try
            {
                string sql = @"SELECT title, stocks FROM ( SELECT title, stocks, ROW_NUMBER() OVER () AS row_num FROM books) AS user_with_rownum WHERE user_with_rownum.row_num > (SELECT COUNT(*) FROM books) - 7";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Books books = new Books();
                            books.title  = dtr["title"].ToString();
                            books.stocks = Convert.ToInt32(dtr["stocks"]); 
                            list.Add(books);
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

    }
}
