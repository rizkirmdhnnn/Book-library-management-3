using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_library_member.Models.entity;
using book_library_member.Models.context;
using System.Windows.Forms;

namespace book_library_member.Models.repository
{
    public class historyRepository
    {
        private SQLiteConnection _connection;

        public historyRepository(DbContext context)
        {
            _connection = context.Conn;
        }

        public List<history> getHistoryByUsername(history history)
        {
            List<history> list = new List<history>();
            string sql = @"SELECT title, isbn, transaction_date, status FROM history";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _connection))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            history histoy = new history();
                            histoy.title = dtr["title"].ToString();
                            histoy.isbn = dtr["isbn"].ToString();
                            histoy.transaction_date = dtr["transaction_date"].ToString();
                            histoy.status = dtr["status"].ToString();
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
    }
}
