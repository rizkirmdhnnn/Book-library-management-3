using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Controllers;
using Book_library_management_3.Views.Dashboard.Books_Section;

namespace Book_library_management_3.Views
{
    public partial class BooksUC : UserControl
    {
        private BooksControler _booksControler;
        List<Books> lvbook = new List<Books>();


        public BooksUC()
        {
            _booksControler = new BooksControler();
            InitializeComponent();
            InitializeListView();
            loadData();
        }

        private void loadData()
        {
            lv_Books.Items.Clear();
            txt_total.Text = _booksControler.getTotalBook().ToString();
            lvbook = _booksControler.getAllBooks();

            foreach (Books Books in lvbook)
            {
                var item = new ListViewItem();
                item.SubItems.Add(Books.isbn);
                item.SubItems.Add(Books.title);
                item.SubItems.Add(Books.writter);
                item.SubItems.Add(Books.genre);
                item.SubItems.Add(Books.publisher);
                item.SubItems.Add(Books.stocks.ToString());
                lv_Books.Items.Add(item);

            }
        }

        private void InitializeListView()
        {
            lv_Books.View = System.Windows.Forms.View.Details;
            lv_Books.FullRowSelect = true;
            lv_Books.GridLines = true;
            lv_Books.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_Books.Columns.Add("ISBN", 150, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Title Book", 210, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Writter Book", 122, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Genre Book", 100, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Publisher", 110, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Stocks", 100, HorizontalAlignment.Left);
        }


        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            lv_Books.Items.Clear();

            Books books = new Books();
            books.title = txt_username.Text;

            lvbook = _booksControler.getBookByTitle(books);

            foreach (Books Books in lvbook)
            {
                var item = new ListViewItem();
                item.SubItems.Add(Books.isbn);
                item.SubItems.Add(Books.title);
                item.SubItems.Add(Books.writter);
                item.SubItems.Add(Books.genre);
                item.SubItems.Add(Books.publisher);
                item.SubItems.Add(Books.stocks.ToString());
                lv_Books.Items.Add(item);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            popUp_Books popUp = new popUp_Books("Add Book", _booksControler);
            popUp.OnCreate += OnCreateEventHandler;

            popUp.Show();
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Books books)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            lvbook.Add(books);
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(books.isbn);
            item.SubItems.Add(books.title);
            item.SubItems.Add(books.writter);
            item.SubItems.Add(books.genre);
            item.SubItems.Add(books.publisher);
            item.SubItems.Add(books.stocks.ToString());
            lv_Books.Items.Add(item);
        }
        // method event handler untuk merespon event OnUpdate,
    }
}
