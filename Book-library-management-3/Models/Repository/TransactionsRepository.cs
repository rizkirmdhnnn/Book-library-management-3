using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Models.Context;
using Book_library_management_3.Models.Repository;


namespace Book_library_management_3.Models.Repository
{
    public class transactionsRepository
    {
        private SQLiteConnection _connection;

        public transactionsRepository(DbContext context)
        {
            _connection = context.Conn;
        }
        public int borrowingBook(Transactions transactions)
        {
            int result = 0;

            string sqlCheckUserBorrowing = @"SELECT username, isbn, date  FROM transactions WHERE username = @username AND isbn = @isbn AND status = 'Peminjaman'";
            string sqlInsert = @"INSERT INTO transactions (transaction_id, username, isbn, date, status) VALUES  (@transaction_id, @username, @isbn, @date, @status)";
            string sqlCheckStock = @"SELECT stocks FROM books WHERE isbn = @isbn";

            using (SQLiteCommand checkUserBorrowing = new SQLiteCommand(sqlCheckUserBorrowing, _connection))
            {

                checkUserBorrowing.Parameters.AddWithValue("@username", transactions.username);
                checkUserBorrowing.Parameters.AddWithValue("@isbn", transactions.isbn);

                object resultObj = checkUserBorrowing.ExecuteScalar();

                if (resultObj != null) // Jika baris ditemukan, buku masih dipinjam
                {
                    result = 00;
                    return result;
                } else
                {
                    using (SQLiteCommand checkStock = new SQLiteCommand(sqlCheckStock, _connection))
                    {
                        checkStock.Parameters.AddWithValue("@isbn", transactions.isbn);

                        int stock = (int)checkStock.ExecuteScalar();

                        if (stock > 0)
                        {

                            using (SQLiteCommand command = new SQLiteCommand(sqlInsert, _connection))
                            {
                                command.Parameters.AddWithValue("@transaction_id", transactions.transactions_id);
                                command.Parameters.AddWithValue("@username", transactions.username);
                                command.Parameters.AddWithValue("@isbn", transactions.isbn);
                                command.Parameters.AddWithValue("@date", DateTime.Now);
                                command.Parameters.AddWithValue("@status", "Peminjaman");

                                try
                                {
                                    result = command.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.Print("Create error : {0}", ex.Message);
                                }
                            }
                        }

                    }

                }
            }

            if (result !=0 || result != 00){

                Books book = new Books();
                book.isbn = transactions.isbn;
                using (DbContext context = new DbContext())
                {
                    var books = new BooksRepository(context);
                    books.updateStocksBooks(book, "-");
                }
            }

            return result;
        }

        public int returnBook(Transactions transactions)
        {

            int result = 0;

            string sql = @"insert into transactions (transaction_id, username, isbn, date, status) values  (@transaction_id, @username, @isbn, @date, @status)";

            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@transaction_id", transactions.transactions_id);
                command.Parameters.AddWithValue("@username", transactions.username);
                command.Parameters.AddWithValue("@isbn", transactions.isbn);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@status", "pengembalian");

                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error : {0}", ex.Message);
                }
            }

            if (result != 0)
            {

                Books book = new Books();
                book.isbn = transactions.isbn;
                using (DbContext context = new DbContext())
                {
                    var books = new BooksRepository(context);
                    books.updateStocksBooks(book, "+");
                }
            }

            return result;

        }

        public List<Transactions> getAllTransactions()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Transactions> list = new List<Transactions>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT * FROM transaction";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    // membuat objek dtr (data reader) untuk menampung result  (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari set
                    while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Transactions trx = new Transactions();
                            trx.transactions_id = (int)dtr["transaction_id"];
                            trx.username = dtr["username"].ToString();
                            trx.isbn = dtr["isbn"].ToString();
                            trx.date = dtr["date"].ToString();
                            trx.status = dtr["status"].ToString();
                            list.Add(trx);
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


        public List<Transactions> getTransactionByUsername(string username)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Transactions> list = new List<Transactions>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT * FROM transactions WHERE username = @username";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@username", username);
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Transactions trx = new Transactions();
                            trx.transactions_id = (int)dtr["transaction_id"];
                            trx.username = dtr["username"].ToString();
                            trx.isbn = dtr["isbn"].ToString();
                            trx.date = dtr["date"].ToString();
                            trx.status = dtr["status"].ToString();
                            list.Add(trx);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getTransactionByUsername error: {0}",
               ex.Message);
            }
            return list;
        }

        }
}
