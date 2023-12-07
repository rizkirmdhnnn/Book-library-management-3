using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book_library_management_3.Controllers;
using Book_library_management_3.Models.Entity;

namespace Book_library_management_3.Views.Dashboard.Profile_Section
{
    public partial class Profile : Form
    {
        private UsersControler _usersControler;
        public Users _users;
        public Profile()
        {
            _usersControler = new UsersControler();
            InitializeComponent();
            this.Size = new System.Drawing.Size(386, 350);
        }

        public Profile(string name) :this() 
        {
            txtbox_Name.Text = name;
            txt_email.Text = _usersControler.getEmailByUsername(txtbox_Name.Text);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(386, 492);
            txtbox_Name.Enabled = true;
            txt_email.Enabled = true;
            panel_profile.Visible = true;
            
        }
    }
}
