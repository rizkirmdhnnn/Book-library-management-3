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
using Microsoft.Office.Interop.Excel;


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
                item.SubItems.Add(history.username);
                item.SubItems.Add(history.status);
                item.SubItems.Add(history.title);
                item.SubItems.Add(history.isbn);
                item.SubItems.Add(history.date);
                lv_History.Items.Add(item);

            }

        }
        private void InitializeListView()
        {
            lv_History.View = System.Windows.Forms.View.Details;
            lv_History.FullRowSelect = true;
            lv_History.GridLines = true;
            lv_History.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_History.Columns.Add("Username", 100, HorizontalAlignment.Left);
            lv_History.Columns.Add("Status", 100, HorizontalAlignment.Left);
            lv_History.Columns.Add("Title Book", 210, HorizontalAlignment.Left);
            lv_History.Columns.Add("ISBN Book", 125, HorizontalAlignment.Left);
            lv_History.Columns.Add("Date", 200, HorizontalAlignment.Left);
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
                item.SubItems.Add(history.username);
                item.SubItems.Add(history.status);
                item.SubItems.Add(history.title);
                item.SubItems.Add(history.isbn);
                item.SubItems.Add(history.date);
                lv_History.Items.Add(item);

            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;

                    app.Visible = false;
                    for (int j = 1; j <= lv_History.Columns.Count; j++)
                    {
                        var newWidth = Math.Min(255, lv_History.Columns[j - 1].Width / 2);
                        ws.Columns[j].ColumnWidth = newWidth;
                        ws.Cells[1, j] = lv_History.Columns[j - 1].Text;
                    }
                    int i = 2;
                    foreach (ListViewItem item in lv_History.Items)
                    {
                        for (int k = 1; k <= item.SubItems.Count; k++)
                        {
                            ws.Cells[i, k] = item.SubItems[k - 1].Text;
                        }
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    MessageBox.Show("Exported Successfully.");

                }
            }
        }
    }
}
