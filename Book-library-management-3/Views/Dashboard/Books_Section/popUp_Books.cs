﻿using System;
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
using System.Text.RegularExpressions;

namespace Book_library_management_3.Views.Dashboard.Books_Section
{
    public partial class popUp_Books : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Books books);

        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;

        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;

        // deklarasi objek controller
        private BooksControler _booksControler;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek mahasiswa
        private Books _books;

        public popUp_Books()
        {
            InitializeComponent();
        }

        
        public popUp_Books(string title, BooksControler controler) : this()

        {

            this.Text = title;
            txt_Label.Text = title;
            _booksControler = controler;
        }


        public popUp_Books(string title, Books books, BooksControler controler) : this()
        {

            this.Text = title;
            txt_Label.Text = title;
            this._booksControler = controler;

            isNewData = false;
            _books = books;

            txtbox_Isbn.Text = _books.isbn;
            txtbox_Title.Text = _books.title;
            txtbox_Writter.Text = _books.writter;
            txtbox_Genre.Text = _books.genre;
            txtbox_Publisher.Text = _books.publisher;
            txtbox_Stocks.Text = _books.stocks.ToString();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(isNewData) _books = new Books();

            _books.isbn = txtbox_Isbn.Text;
            _books.title = txtbox_Title.Text;
            _books.writter = txtbox_Writter.Text;
            _books.genre = txtbox_Genre.Text;
            _books.publisher = txtbox_Publisher.Text;
            if(txtbox_Stocks.Text != "")
            {
                _books.stocks = Convert.ToInt32(txtbox_Stocks.Text);
            }
            int result = 0;

            if(isNewData)
            {
                result = _booksControler.addBook( _books);

                if(result > 0 ) {

                    OnCreate(_books);

                    txtbox_Isbn.Clear();
                    txtbox_Title.Clear();
                    txtbox_Writter.Clear();
                    txtbox_Genre.Clear();
                    txtbox_Publisher.Clear();
                    txtbox_Stocks.Clear();

                    txtbox_Isbn.Focus();
                }
            } else
            {
                result = _booksControler.updateBook( _books);
                if (result > 0)
                {
                    OnUpdate(_books);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ada yg salah dengan controler");
                }

            }
        }

        private void txtbox_Stocks_TextChanged(object sender, EventArgs e)
        {
            string input = txtbox_Stocks.Text;
            if (!Regex.IsMatch(input, "^[0-9]*$"))
            {
                MessageBox.Show("Only numbers are allowed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_Stocks.Text = Regex.Replace(input, "[^0-9]", "");
                txtbox_Stocks.SelectionStart = txtbox_Stocks.Text.Length;
            }
        }
    }
}