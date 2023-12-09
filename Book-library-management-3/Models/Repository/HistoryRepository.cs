using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using Book_library_management_3.Models.Context;
using Book_library_management_3.Models.Entity;


namespace Book_library_management_3.Models.Repository
{

    public class HistoryRepository
    {
        private SQLiteConnection _connection;

        public HistoryRepository(DbContext context)
        {
            _connection = context.Conn;
        }

        public List<History> getAllHistory()
        {
            List<History> list = new List<History>();
            string sql = @"SELECT username, status, isbn, title ,transaction_date FROM history";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    // membuat objek dtr (data reader) untuk menampung result  (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            History histoy = new History();
                            histoy.username = dtr["username"].ToString();
                            histoy.status = dtr["status"].ToString();
                            histoy.isbn = dtr["isbn"].ToString();
                            histoy.title = dtr["title"].ToString();
                            histoy.transaction_date = dtr["transaction_date"].ToString();
                            list.Add(histoy);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"SQLite Error: {ex.Message}. Query: {sql}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"getAllTransactions error: {ex.Message}");
            }


            return list;

        }

        public List<History> getHistoryByUsername(History history)
        {
            List<History> list = new List<History>();
            try
            {
                string sql = @"SELECT username, status, isbn, title ,transaction_date FROM history WHERE username LIKE @username";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@username", history.username + '%');
                    // membuat objek dtr (data reader) untuk menampung result  (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {

                        // panggil method Read untuk mendapatkan baris dari set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            History histoy = new History();
                            histoy.username = dtr["username"].ToString();
                            histoy.status = dtr["status"].ToString();
                            histoy.isbn = dtr["isbn"].ToString();
                            histoy.title = dtr["title"].ToString();
                            histoy.transaction_date = dtr["transaction_date"].ToString();
                            list.Add(histoy);
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
