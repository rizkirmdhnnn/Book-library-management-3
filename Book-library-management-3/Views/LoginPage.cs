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
    public partial class LoginPage : Form
    {
        
        public LoginPage()
        {
            InitializeComponent();      
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            Users users = new Users()
            {
                username = txtBox_username.Text,
                password = txtBox_password.Text
            };

            UsersControler _usersControler = new UsersControler();
            string result = _usersControler.checkUserAdmin(users);

            if (result != "") this.Hide();
        }

        private void txtBox_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBox_password.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

    }
}
