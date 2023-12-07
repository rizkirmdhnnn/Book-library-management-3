using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Book_library_management_3.Models.Context
{
    public class DbContext : IDisposable
    {

        private SQLiteConnection _conn;

        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                string dbName = Directory.GetCurrentDirectory() + "\\Database\\book-libray-management.db";

                string connectionString = string.Format("Data Source ={0}; FailIfMissing = True", dbName);

                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
            }
            return conn;
        }


        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
