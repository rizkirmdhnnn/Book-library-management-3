﻿using System;
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
            try
            {
                string sql = 
                    @"SELECT  
                        transactions.username, 
	                    transactions.status,
                        books.title,	
                        transactions.isbn, 
                        transactions.date  
                    FROM 
                        history
                    JOIN 
                        transactions ON history.transaction_id = transactions.transaction_id
                    JOIN 
                        books ON transactions.isbn = books.isbn;";
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
                            histoy.title = dtr["title"].ToString();
                            histoy.isbn = dtr["isbn"].ToString();
                            histoy.date = dtr["date"].ToString();
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

        public List<History> getHistoryByUsername(History history)
        {
            List<History> list = new List<History>();
            try
            {
                string sql = @"SELECT  
                                    transactions.username, 
	                                transactions.status,
                                    books.title,	
                                    transactions.isbn, 
                                    transactions.date  
                                FROM 
                                    history
                                JOIN 
                                    transactions ON history.transaction_id = transactions.transaction_id
                                JOIN 
                                    books ON transactions.isbn = books.isbn
                                WHERE 
	                                username LIKE @username";
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
                            histoy.title = dtr["title"].ToString();
                            histoy.isbn = dtr["isbn"].ToString();
                            histoy.date = dtr["date"].ToString();
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

        public int addHistory(History history)
        {
            int result = 0;

            string sql = @"INSERT into history (transaction_id) values (@transaction_id)";

            using (SQLiteCommand cmd = new SQLiteCommand( sql, _connection))
            {
                cmd.Parameters.AddWithValue("@transaction_id", history.transactions_id);
                try
                {
                    result = cmd.ExecuteNonQuery();
                } catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error : {0}", ex.Message);

                }
            }

            return result;
        }
    }
}
