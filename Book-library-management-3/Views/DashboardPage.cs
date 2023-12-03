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
    public partial class DashboardPage : Form
    {
        public DashboardPage()
        {
            InitializeComponent();
            DashboardUC dashboardUC = new DashboardUC();
            addUserControl(dashboardUC);
        }

        private void addUserControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            dashboardPanel.Controls.Clear();
            dashboardPanel.Controls.Add(control);
            dashboardPanel.BringToFront();

        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            btn_dashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btn_dashboard.ForeColor = Color.White;
            btn_dashboard.Image = global::Book_library_management_3.Properties.Resources.Dashboard_ON;
            btn_books.FillColor = System.Drawing.Color.Transparent;
            btn_books.ForeColor = Color.Black;
            btn_books.Image = global::Book_library_management_3.Properties.Resources.Books;
            btn_transactions.FillColor = System.Drawing.Color.Transparent;
            btn_transactions.ForeColor = Color.Black;
            btn_transactions.Image = global::Book_library_management_3.Properties.Resources.Transaction;
            btn_return.FillColor = System.Drawing.Color.Transparent;
            btn_return.ForeColor = Color.Black;
            btn_return.Image = global::Book_library_management_3.Properties.Resources.Return;
            btn_history.FillColor = System.Drawing.Color.Transparent;
            btn_history.ForeColor = Color.Black;
            btn_history.Image = global::Book_library_management_3.Properties.Resources.History;
            btn_member.FillColor = System.Drawing.Color.Transparent;
            btn_member.ForeColor = Color.Black;
            btn_member.Image = global::Book_library_management_3.Properties.Resources.Members;

            DashboardUC dashboardUC = new DashboardUC();
            addUserControl(dashboardUC);
        }

        private void btn_books_Click(object sender, EventArgs e)
        {
            btn_dashboard.FillColor = System.Drawing.Color.Transparent;
            btn_dashboard.ForeColor= Color.Black;
            btn_dashboard.Image = global::Book_library_management_3.Properties.Resources.Dashboard;
            btn_books.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btn_books.ForeColor = Color.White;
            btn_books.Image = global::Book_library_management_3.Properties.Resources.Books_ON;
            btn_transactions.FillColor = System.Drawing.Color.Transparent;
            btn_transactions.ForeColor = Color.Black;
            btn_transactions.Image = global::Book_library_management_3.Properties.Resources.Transaction;
            btn_return.FillColor = System.Drawing.Color.Transparent;
            btn_return.ForeColor = Color.Black;
            btn_return.Image = global::Book_library_management_3.Properties.Resources.Return;
            btn_history.FillColor = System.Drawing.Color.Transparent;
            btn_history.ForeColor = Color.Black;
            btn_history.Image = global::Book_library_management_3.Properties.Resources.History;
            btn_member.FillColor = System.Drawing.Color.Transparent;
            btn_member.ForeColor = Color.Black;
            btn_member.Image = global::Book_library_management_3.Properties.Resources.Members;

            BooksUC booksUC = new BooksUC();
            addUserControl(booksUC);
        }

        private void btn_transactions_Click(object sender, EventArgs e)
        {
            btn_dashboard.FillColor = System.Drawing.Color.Transparent;
            btn_dashboard.ForeColor= Color.Black;
            btn_dashboard.Image = global::Book_library_management_3.Properties.Resources.Dashboard;
            btn_books.FillColor = System.Drawing.Color.Transparent;
            btn_books.ForeColor= Color.Black;
            btn_books.Image = global::Book_library_management_3.Properties.Resources.Books;
            btn_transactions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btn_transactions.ForeColor= Color.White;
            btn_transactions.Image = global::Book_library_management_3.Properties.Resources.Transaction_ON;
            btn_return.FillColor = System.Drawing.Color.Transparent;
            btn_return.ForeColor = Color.Black;
            btn_return.Image = global::Book_library_management_3.Properties.Resources.Return;
            btn_history.FillColor = System.Drawing.Color.Transparent;
            btn_history.ForeColor= Color.Black;
            btn_history.Image = global::Book_library_management_3.Properties.Resources.History;
            btn_member.FillColor = System.Drawing.Color.Transparent;
            btn_member.ForeColor= Color.Black;
            btn_member.Image = global::Book_library_management_3.Properties.Resources.Members;

            TransactionsUC transactionsUC= new TransactionsUC();
            addUserControl(transactionsUC);
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            btn_dashboard.FillColor = System.Drawing.Color.Transparent;
            btn_dashboard.ForeColor= Color.Black;
            btn_dashboard.Image = global::Book_library_management_3.Properties.Resources.Dashboard;
            btn_books.FillColor = System.Drawing.Color.Transparent;
            btn_books.ForeColor= Color.Black;
            btn_books.Image = global::Book_library_management_3.Properties.Resources.Books;
            btn_transactions.FillColor = System.Drawing.Color.Transparent;
            btn_transactions.ForeColor= Color.Black;
            btn_transactions.Image = global::Book_library_management_3.Properties.Resources.Transaction;
            btn_return.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btn_return.ForeColor= Color.White;
            btn_return.Image = global::Book_library_management_3.Properties.Resources.Return_ON;
            btn_history.FillColor = System.Drawing.Color.Transparent;
            btn_history.ForeColor= Color.Black;
            btn_history.Image = global::Book_library_management_3.Properties.Resources.History;
            btn_member.FillColor = System.Drawing.Color.Transparent;
            btn_member.ForeColor= Color.Black;
            btn_member.Image = global::Book_library_management_3.Properties.Resources.Members;

            ReturnUC returnUC= new ReturnUC();
            addUserControl(returnUC);
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            btn_dashboard.FillColor = System.Drawing.Color.Transparent;
            btn_dashboard.ForeColor= Color.Black;
            btn_dashboard.Image = global::Book_library_management_3.Properties.Resources.Dashboard;
            btn_books.FillColor = System.Drawing.Color.Transparent;
            btn_books.ForeColor = Color.Black;
            btn_books.Image = global::Book_library_management_3.Properties.Resources.Books;
            btn_transactions.FillColor = System.Drawing.Color.Transparent;
            btn_transactions.ForeColor= Color.Black;
            btn_transactions.Image = global::Book_library_management_3.Properties.Resources.Transaction;
            btn_return.FillColor = System.Drawing.Color.Transparent;
            btn_return.ForeColor= Color.Black;
            btn_return.Image = global::Book_library_management_3.Properties.Resources.Return;
            btn_history.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btn_history.ForeColor= Color.White;
            btn_history.Image = global::Book_library_management_3.Properties.Resources.History_ON;
            btn_member.FillColor = System.Drawing.Color.Transparent;
            btn_member.ForeColor= Color.Black;
            btn_member.Image = global::Book_library_management_3.Properties.Resources.Members;

            HistoryUC historyUC= new HistoryUC();
            addUserControl(historyUC);
        }

        private void btn_member_Click(object sender, EventArgs e)
        {
            btn_dashboard.FillColor = System.Drawing.Color.Transparent;
            btn_dashboard.ForeColor= Color.Black;
            btn_dashboard.Image = global::Book_library_management_3.Properties.Resources.Dashboard;
            btn_books.FillColor = System.Drawing.Color.Transparent;
            btn_books.ForeColor= Color.Black;
            btn_books.Image = global::Book_library_management_3.Properties.Resources.Books;
            btn_transactions.FillColor = System.Drawing.Color.Transparent;
            btn_transactions.ForeColor= Color.Black;
            btn_transactions.Image = global::Book_library_management_3.Properties.Resources.Transaction;
            btn_return.FillColor = System.Drawing.Color.Transparent;
            btn_return.ForeColor= Color.Black;
            btn_return.Image = global::Book_library_management_3.Properties.Resources.Return;
            btn_history.FillColor = System.Drawing.Color.Transparent;
            btn_history.ForeColor= Color.Black;
            btn_history.Image = global::Book_library_management_3.Properties.Resources.History;
            btn_member.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            btn_member.ForeColor= Color.White;
            btn_member.Image = global::Book_library_management_3.Properties.Resources.Members_ON;

            MembersUC membersUC= new MembersUC();
            addUserControl(membersUC);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }
    }
}
