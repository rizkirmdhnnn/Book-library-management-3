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
using System.Net.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;


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
            string sqlInsert = @"INSERT INTO transactions (username, isbn, date, status) VALUES  (@username, @isbn, @date, @status)";
            string sqlCheckStock = @"SELECT stocks FROM books WHERE isbn = @isbn";

            using (SQLiteCommand checkUserBorrowing = new SQLiteCommand(sqlCheckUserBorrowing, _connection))
            {

                checkUserBorrowing.Parameters.AddWithValue("@username", transactions.username);
                checkUserBorrowing.Parameters.AddWithValue("@isbn", transactions.isbn);

                object resultObj = checkUserBorrowing.ExecuteScalar();


                if (resultObj != null) // Jika baris ditemukan, buku masih dipinjam
                {
                    result = 00;
                    MessageBox.Show("Buku Masih Dipinjam");
                    return result;
                } else
                {
                    using (SQLiteCommand checkStock = new SQLiteCommand(sqlCheckStock, _connection))
                    {
                        checkStock.Parameters.AddWithValue("@isbn", transactions.isbn);
                        int stock = 0;

                        using(SQLiteDataReader dtr = checkStock.ExecuteReader())
                        {
                            while (dtr.Read()) {
                                stock = dtr.GetInt32(0);
                            }
                        }

                        MessageBox.Show(stock.ToString());

                        if (stock > 0)
                        {

                            using (SQLiteCommand command = new SQLiteCommand(sqlInsert, _connection))
                            {
                                command.Parameters.AddWithValue("@username", transactions.username);
                                command.Parameters.AddWithValue("@isbn", transactions.isbn);
                                command.Parameters.AddWithValue("@date", transactions.date);
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
            MessageBox.Show("Berhasil Meminjam Buku" + result.ToString());
            if (result == 1){

                //Mengurangi Stocks
                Books book = new Books();
                book.isbn = transactions.isbn;
                using (DbContext context = new DbContext())
                {
                    var books = new BooksRepository(context);
                    int p = books.updateStocksBooks(book, '-');

                    MessageBox.Show("Berhasil Mengurangi Stock" + p.ToString());
                }

                //Membuat history
                History history = new History();
                using (DbContext context = new DbContext())
                {
                    var transaction_id = new transactionsRepository(context);
                    history.transactions_id = transaction_id.getTransaction_id();

                    using (DbContext transaction_context = new DbContext())
                    {
                        var _history = new HistoryRepository(transaction_context);
                        int hasil = _history.addHistory(history);
                        MessageBox.Show("Hasil tambah history : " + hasil.ToString());
                    }
                }

            }

            return result;
        }
        

        public int getTransaction_id()
        {
            int result = 0;
            try
            {
                string sql = @"SELECT transaction_id FROM transactions ORDER BY date DESC LIMIT 1;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            result = dtr.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getAllTransactions error: {0}", ex.Message);
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
                command.Parameters.AddWithValue("@date", transactions.date);
                command.Parameters.AddWithValue("@status", "Pengembalian");

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
                    books.updateStocksBooks(book, '+');
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
                string sql = @"SELECT  
                                    transactions.username, 
                                    books.title,	
                                    transactions.isbn, 
                                    transactions.date  
                                FROM 
                                    transactions
                                JOIN 
                                    books ON transactions.isbn = books.isbn";
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
                            trx.username = dtr["username"].ToString();
                            trx.title = dtr["title"].ToString();
                            trx.isbn = dtr["isbn"].ToString();
                            trx.date = dtr["date"].ToString();
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

        public List<Transactions> getBorrowingByUsername(string username)
        {
            List <Transactions> list = new List<Transactions>();

            string sql = @"SELECT * FROM transactions WHERE username = @username";

            using(SQLiteCommand cmd = new SQLiteCommand(sql,_connection))
            {
                cmd.Parameters.AddWithValue ("@username", username);

                using(SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while(dtr.Read())
                    {
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
            return list;
        }

        public int getTotalBorrowingBook()
        {
            int result = 0;

            string sql = @"SELECT COUNT(*) FROM transactions WHERE status = 'Peminjaman'";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
            {
                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: {0}. Query: {1}", ex.Message, cmd);
                }
            }

            return result;
        }

        public int getTotalReturnedBook()
        {
            int result = 0;

            string sql = @"SELECT COUNT(*) FROM transactions WHERE status = 'Pengembalian'";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
            {
                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: {0}. Query: {1}", ex.Message, cmd);
                }
            }

            return result;
        }

    }
}
