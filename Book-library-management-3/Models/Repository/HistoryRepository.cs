using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                string sql = @"SELECT history_id, transaction_id, username, books.title,date,status FROM history JOIN books ON history.isbn = books.isbn";
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
                            histoy.history_id = Convert.ToInt32(dtr["history_id"]);
                            histoy.transactions_id = Convert.ToInt32(dtr["transaction_id"]);
                            histoy.username = dtr["username"].ToString();
                            histoy.title = dtr["title"].ToString();
                            histoy.date = dtr["date"].ToString();
                            histoy.status = dtr["status"].ToString();
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
