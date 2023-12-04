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
using Guna.UI2.AnimatorNS;

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

        private void OnCreateEventHandler(Books books)
        {
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

        private void OnUpdateEventHandler(Books books)
        {
            // ambil index data mhs yang edit
            int index = lv_Books.SelectedIndices[0];
            // update informasi mhs di listview
            ListViewItem itemRow = lv_Books.Items[index];
            itemRow.SubItems[1].Text = books.isbn;
            itemRow.SubItems[2].Text = books.title;
            itemRow.SubItems[3].Text = books.writter;
            itemRow.SubItems[4].Text = books.genre;
            itemRow.SubItems[5].Text = books.writter;
            itemRow.SubItems[6].Text = books.stocks.ToString();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lv_Books.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Do you want to delete the book data?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Books books =  lvbook[lv_Books.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = _booksControler.deleteBook(books);
                    if (result > 0) loadData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Book data has not been selected", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (lv_Books.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Books books = lvbook[lv_Books.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                popUp_Books popUp_Books = new popUp_Books("Edit book data", books, _booksControler);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                popUp_Books.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                popUp_Books.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan",
               MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }
    }
}
