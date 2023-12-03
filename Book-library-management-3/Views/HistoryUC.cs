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
    public partial class HistoryUC : UserControl
    {
        private HistoryControler _historyControler;
        List<History> histories = new List<History>();
        public HistoryUC()
        {
            _historyControler = new HistoryControler();
            InitializeComponent();
            InitializeListView();
            loadData();
        }


        private void loadData()
        {
            lv_History.Items.Clear();

            histories = _historyControler.getAllHistory();

            foreach (History history in histories)
            {
                var item = new ListViewItem();
                item.SubItems.Add(history.history_id.ToString());
                item.SubItems.Add(history.transactions_id.ToString());
                item.SubItems.Add(history.username);
                item.SubItems.Add(history.title);
                item.SubItems.Add(history.date);
                item.SubItems.Add(history.status);
                lv_History.Items.Add(item);

            }

        }
        private void InitializeListView()
        {
            lv_History.View = System.Windows.Forms.View.Details;
            lv_History.FullRowSelect = true;
            lv_History.GridLines = true;
            lv_History.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_History.Columns.Add("Histoy ID", 100, HorizontalAlignment.Left);
            lv_History.Columns.Add("Transaction ID", 100, HorizontalAlignment.Left);
            lv_History.Columns.Add("Username", 125, HorizontalAlignment.Left);
            lv_History.Columns.Add("Title Book", 210, HorizontalAlignment.Left);
            lv_History.Columns.Add("Date", 110, HorizontalAlignment.Left);
            lv_History.Columns.Add("Status", 145, HorizontalAlignment.Left);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lv_History.Items.Clear();

            History his = new History();
            his.username = txtbox_username.Text;

            histories = _historyControler.getHistoryByUsername(his);

            foreach (History history in histories)
            {
                var item = new ListViewItem();
                item.SubItems.Add(history.history_id.ToString());
                item.SubItems.Add(history.transactions_id.ToString());
                item.SubItems.Add(history.username);
                item.SubItems.Add(history.title);
                item.SubItems.Add(history.date);
                item.SubItems.Add(history.status);
                lv_History.Items.Add(item);

            }
        }
    }
}
