using Book_library_management_3.Controllers;
using Book_library_management_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_library_management_3.Views
{
    public partial class ReturnUC : UserControl
    {
        private TransactionControler _transactionControler;
        List<Transactions> _transactions = new List<Transactions>();

        public ReturnUC()
        {
            _transactionControler = new TransactionControler();
            InitializeComponent();
            InitializeListView();
            loadDataListView();
        }

        private void InitializeListView()
        {
            Lv_Transactions.View = System.Windows.Forms.View.Details;
            Lv_Transactions.FullRowSelect = true;
            Lv_Transactions.GridLines = true;
            Lv_Transactions.Columns.Add("", 0, HorizontalAlignment.Right);
            Lv_Transactions.Columns.Add("Username", 135, HorizontalAlignment.Left);
            Lv_Transactions.Columns.Add("Title Book", 135, HorizontalAlignment.Left);
            Lv_Transactions.Columns.Add("ISBN Book", 135, HorizontalAlignment.Left);
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

        private void txtbox_username_TextChanged(object sender, EventArgs e)
        {
            Lv_Transactions.Items.Clear();
            _transactions = _transactionControler.getTransactionsByUsername(txtbox_username.Text);

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

        private void btn_return_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions();
            if (Lv_Transactions.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = Lv_Transactions.SelectedItems[0];
                transactions.username = selectedItem.SubItems[1].Text;
                transactions.isbn = selectedItem.SubItems[3].Text;
                transactions.date = selectedItem.SubItems[4].Text;

                int resutl = _transactionControler.returnBook(transactions);
                MessageBox.Show(resutl.ToString());
            }
            else // data belum dipilih
            {
                MessageBox.Show("Account has not been selected", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
