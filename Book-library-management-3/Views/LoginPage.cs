using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book_library_management_3.Models.Context;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Models.Repository;

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

            DbContext dbContext = new DbContext();
            Users usr = new Users();
            usr.username = txtBox_username.Text;
            usr.password = txtBox_password.Text;

            usersRepository login = new usersRepository(dbContext);
            int result = login.checkUserAdmin(usr);
            if (result == 0)
            {
                MessageBox.Show("User tidak ada");
            } else
            {
                MessageBox.Show("user ada");
            }

        }
    }
}
