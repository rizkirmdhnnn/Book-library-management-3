using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book_library_management_3.Controllers;

namespace Book_library_management_3.Views
{
    public partial class DashboardUC : UserControl
    {
        private TransactionControler transactionControler;
        private BooksControler booksControler;
        private UsersControler usersControler;
        
        public DashboardUC()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            transactionControler = new TransactionControler();
            booksControler = new BooksControler();
            usersControler = new UsersControler();

            txt_members.Text = usersControler.getTotalMembers().ToString();
            txt_totalBook.Text = booksControler.getTotalBook().ToString();
            txt_borrowing.Text = transactionControler.getTotalBorrowingBook().ToString();
            txt_returned.Text = transactionControler.getTotalReturnedBook().ToString();
        }



    }
}
