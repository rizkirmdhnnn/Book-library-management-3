using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Histoy> getAllHistory()
        {
            List<Histoy> list = new List<Histoy>();
            try
            {
                string sql = @"select * from history";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    // membuat objek dtr (data reader) untuk menampung result  (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Histoy histoy = new Histoy();
                            histoy.history_id = (int)dtr["history_id"];
                            histoy.transactions_id = (int)dtr["transaction_id"];
                            histoy.username = dtr["username"].ToString();
                            histoy.isbn = dtr["isbn"].ToString();
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
