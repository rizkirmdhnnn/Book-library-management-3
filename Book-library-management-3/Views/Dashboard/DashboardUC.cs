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
using Book_library_management_3.Models.Entity;

namespace Book_library_management_3.Views
{
    public partial class DashboardUC : UserControl
    {
        private TransactionControler transactionControler;
        private BooksControler booksControler;
        private UsersControler usersControler;
        private List<Users> listRecentMembers = new List<Users>();
        private List<Books> listRecentBooks = new List<Books>();

        public DashboardUC()
        {
            InitializeComponent();
            InisialisasiListView();
            loadData();
        }


        private void loadData()
        {
            txt_date.Text = DateTime.Now.ToString("MMM dd, yyyy | dddd, hh:mm tt");
            transactionControler = new TransactionControler();
            booksControler = new BooksControler();
            usersControler = new UsersControler();

            txt_members.Text = usersControler.getTotalMembers().ToString();
            txt_totalBook.Text = booksControler.getTotalBook().ToString();
            txt_borrowing.Text = transactionControler.getTotalBorrowingBook().ToString();
            txt_returned.Text = transactionControler.getTotalReturnedBook().ToString();

            lv_RecentMembers.Items.Clear();
            listRecentMembers = usersControler.getRecentMembers();


            lv_RecentBooks.Items.Clear();
            listRecentBooks = booksControler.getRecentBooks();


            foreach (Users user in listRecentMembers)
            {
                var item = new ListViewItem();
                item.SubItems.Add(user.username);
                item.SubItems.Add(user.status);
                lv_RecentMembers.Items.Add(item);
            }


            foreach (Books books in listRecentBooks)
            {
                var item = new ListViewItem();
                item.SubItems.Add(books.title);
                item.SubItems.Add(books.stocks.ToString());
                lv_RecentBooks.Items.Add(item);
            }

        }

        private void InisialisasiListView()
        {
            lv_RecentBooks.View = System.Windows.Forms.View.Details;
            lv_RecentBooks.FullRowSelect = true;
            lv_RecentBooks.GridLines = true;
            lv_RecentBooks.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_RecentBooks.Columns.Add("Book Title", 170, HorizontalAlignment.Left);
            lv_RecentBooks.Columns.Add("Book Stocks", 170, HorizontalAlignment.Left);

            lv_RecentMembers.View = System.Windows.Forms.View.Details;
            lv_RecentMembers.FullRowSelect = true;
            lv_RecentMembers.GridLines = true;
            lv_RecentMembers.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_RecentMembers.Columns.Add("Username", 170, HorizontalAlignment.Left);
            lv_RecentMembers.Columns.Add("Type Account", 170, HorizontalAlignment.Left);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
