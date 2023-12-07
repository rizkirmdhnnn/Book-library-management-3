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
    public partial class TransactionsUC : UserControl
    {
        private UsersControler _usersControler;
        private BooksControler _booksControler;
        private TransactionControler _transactionControler;

        List<Transactions> _transactions = new List<Transactions>();
        public TransactionsUC()
        {
            _usersControler = new UsersControler();
            _booksControler = new BooksControler();
            _transactionControler = new TransactionControler();
            InitializeComponent();
            InitializeListView();
            loadDataListView();
            getUsername();
            getTitle();
            getTime();
        }

        private void InitializeListView()
        {
            Lv_Transactions.View = System.Windows.Forms.View.Details;
            Lv_Transactions.FullRowSelect = true;
            Lv_Transactions.GridLines = true;
            Lv_Transactions.Columns.Add("", 0, HorizontalAlignment.Right);
            Lv_Transactions.Columns.Add("Username", 80, HorizontalAlignment.Left);
            Lv_Transactions.Columns.Add("Title Book", 105, HorizontalAlignment.Left);
            Lv_Transactions.Columns.Add("ISBN Book", 50, HorizontalAlignment.Left);
            Lv_Transactions.Columns.Add("Date", 135, HorizontalAlignment.Left);
        }

        private void loadDataListView()
        {
            Lv_Transactions.Items.Clear();
            _transactions = _transactionControler.getAllTransactions();

            foreach (Transactions transactions in _transactions)
            {
                var item = new ListViewItem();
                item.SubItems.Add(transactions.username);
                item.SubItems.Add(transactions.title);
                item.SubItems.Add(transactions.isbn);
                item.SubItems.Add(transactions.date);
                Lv_Transactions.Items.Add(item);

            }

        }

        private void getUsername()
        {
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete = _usersControler.getUsername();
            txtbox_username.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbox_username.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtbox_username.AutoCompleteCustomSource = autoComplete;

        }

        private void getTitle() {
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete = _booksControler.getTitle();
            txtbox_books.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbox_books.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtbox_books.AutoCompleteCustomSource = autoComplete;

        }

        private void getTime()
        {
            txtbox_date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtbox_date.Enabled = false;
        }


        private void btn_SearchBook_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.title = txtbox_books.Text;
            string result = _booksControler.getDetileBookByTitle(books);
            richTextBox1.Text = result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.title = txtbox_books.Text;
            string result = _booksControler.getIsbnByTitle(books);

            Transactions transactions = new Transactions();
            transactions.isbn = result;
            transactions.username = txtbox_username.Text;
            transactions.status = "Peminjaman";
            transactions.date = txtbox_date.Text;

            _transactionControler.borrowingBook(transactions);
            loadDataListView();
            getTime();
        }

        private void txtbox_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_books_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
