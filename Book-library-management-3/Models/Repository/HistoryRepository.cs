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

        public List<History> getAllHistory()
        {
            List<History> list = new List<History>();
            try
            {
                string sql = @"select * from history";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            History histoy = new History();
                            histoy.history_id = Convert.ToInt32(dtr["history_id"]);
                            histoy.transactions_id = Convert.ToInt32(dtr["transaction_id"]);
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

        public List<History> getHistoryByUsername() { 
        
            List<History> list = new List<History>();
            string sql = @"SELECT * FROM history WHERE username = @username";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            History histoy = new History();
                            histoy.history_id = Convert.ToInt32(dtr["history_id"]);
                            histoy.transactions_id = Convert.ToInt32(dtr["transaction_id"]);
                            histoy.username = dtr["username"].ToString();
                            histoy.isbn = dtr["isbn"].ToString();
                            histoy.date = dtr["date"].ToString();
                            histoy.status = dtr["status"].ToString();
                            list.Add(histoy);
                        }
                    }
                }
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getAllTransactions error: {0}", ex.Message);
            }

            return list;
        
        }
    }
}
