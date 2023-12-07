using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Book_library_management_3.Models.Context;
using Book_library_management_3.Models.Entity;
using System.Windows.Forms;
using Book_library_management_3.Views;

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

        public int updateBook(Books books)
        {
            int result = 0;

            string sql = @"UPDATE books SET title = @title, writter = @writter, genre = @genre, publisher = @publisher, stocks = @stocks WHERE isbn = @isbn";
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

        public int updateStocksBooks(Books books, char IncreseOrDecrease)
        {
            int result = 0;
            string sqlUpdateBook = "";

            if (IncreseOrDecrease == '+')
            {
                sqlUpdateBook = @"UPDATE books SET stocks = stocks + 1 WHERE isbn = @isbn";
            }
            
            if (IncreseOrDecrease == '-')
            {
                sqlUpdateBook = @"UPDATE books SET stocks = stocks - 1 WHERE isbn = @isbn";
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

        public List<Books> getAllBooks()
        {
            List<Books> list = new List<Books>();
            string sql = @"SELECT * FROM books";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Books books = new Books();
                            books.isbn = dtr["isbn"].ToString();
                            books.title = dtr["title"].ToString();
                            books.writter = dtr["writter"].ToString();
                            books.genre = dtr["genre"].ToString();
                            books.publisher = dtr["publisher"].ToString();
                            books.stocks = Convert.ToInt32(dtr["stocks"]);
                            list.Add(books);
                        }
                    }
                }
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getRecentMembers error: {0}", ex.Message);

            }

            return list;
        }

        public List<Books> getBookByTitle(Books getTitleBook)
        {
            List<Books> list = new List<Books>();
            string sql = @"SELECT * FROM books WHERE title LIKE @title";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@title", getTitleBook.title + '%');
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Books books = new Books();
                            books.isbn = dtr["isbn"].ToString();
                            books.title = dtr["title"].ToString();
                            books.writter = dtr["writter"].ToString();
                            books.genre = dtr["genre"].ToString();
                            books.publisher = dtr["publisher"].ToString();
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

        public AutoCompleteStringCollection getTitle()
        {
            string sql = @"SELECT title from books";
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

        public string getDetileBookByTitle(Books books)
        {
            string result = "";
            string sql = @"SELECT * FROM books WHERE title = @title";
            
            using(SQLiteCommand cmd = new SQLiteCommand(sql,_connection))
            {
                cmd.Parameters.AddWithValue("@title", books.title);
                using(SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        
                        result = "Title : " + dtr.GetString(0) + "\rWritter : " + dtr.GetString(1) + "\rISBN : " + dtr.GetString(2) + "\rGenre : " + dtr.GetString(3) + "\rPublisher : " + dtr.GetString(4) + "\rStocks : " + dtr.GetInt32(5);
                    }
                }
            }

            return result;
        }

        public string getIsbnBYTitle(Books books)
        {
            string result = "";
            string sql = @"SELECT isbn FROM books WHERE title = @title";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@title", books.title);
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {

                        result = dtr.GetString(0); ;
                    }
                }
            }

            return result;
        }
    }
}
