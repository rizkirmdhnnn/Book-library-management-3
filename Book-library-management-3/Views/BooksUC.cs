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

namespace Book_library_management_3.Views
{
    public partial class BooksUC : UserControl
    {
        private BooksControler _booksControler;
        List<History> histories = new List<History>();


        public BooksUC()
        {
            _booksControler = new BooksControler();
            InitializeComponent();
            InitializeListView();
            loadData();
        }

        private void loadData()
        {
            txt_total.Text = _booksControler.getTotalBook().ToString();

        }

        private void InitializeListView()
        {
            lv_Books.View = System.Windows.Forms.View.Details;
            lv_Books.FullRowSelect = true;
            lv_Books.GridLines = true;
            lv_Books.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_Books.Columns.Add("ISBN", 180, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Title Book", 210, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Writter Book", 110, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Genre Book", 100, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Publisher", 110, HorizontalAlignment.Left);
            lv_Books.Columns.Add("Stocks", 100, HorizontalAlignment.Left);
        }
    }
}
