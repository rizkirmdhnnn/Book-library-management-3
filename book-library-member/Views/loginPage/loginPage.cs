using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_library_member.Controllers;
using book_library_member.Models.entity;
using book_library_member.Views.dasboard_Section;

namespace book_library_member.Views.loginPage
{
    public partial class loginPage : Form
    {
        private usersController _usersController;
        public loginPage()
        {
            _usersController = new usersController();
            InitializeComponent();
        }

        private void txtBox_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBox_password.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            users _users = new users();
            _users.username = txtBox_username.Text;
            _users.password = txtBox_password.Text;

            string result = _usersController.checkUser(_users);
            if (result != "") { 
                dashboardPage dashboardPage = new dashboardPage();
                dashboardPage.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Data not found, login failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
