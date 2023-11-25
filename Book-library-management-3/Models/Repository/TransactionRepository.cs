using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_library_management_3.Models.Entity;
using Book_Library_Management_3.Models.Context;


namespace Book_Library_Management_3.Models.Repository
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

            string sql = @"insert into transactions (transaction_id, username, isbn, date, status) values  (@transaction_id, @username, @isbn, @date, @status)";

            using (SQLiteCommand command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@transaction_id", transactions.transactions_id);
                command.Parameters.AddWithValue("@username", transactions.username);
                command.Parameters.AddWithValue("@isbn", transactions.isbn);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@status", "peminjaman");

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

            return result;

        }



    }
}
