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
using Book_library_management_3.Views.Dashboard.Books_Section;

namespace Book_library_management_3.Views.Dashboard.Members_Section
{
    public partial class popUp_Members : Form
    {

        public delegate void CreateUpdateEventHandler(Users users);
        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;

        private UsersControler _userControl;
        private bool isNewData = true;
        private Users _users;


        public popUp_Members()
        {
            InitializeComponent();
        }

        public popUp_Members(string title, UsersControler controler) : this()
        {
            this.Text = title;
            txt_Label.Text = title;
            _userControl = controler;
        }

        public popUp_Members(string title, Users users,UsersControler controler) : this()
        {
            this.Text = title;
            txt_Label.Text = title;
            _userControl = controler;

            isNewData = false;
            _users = users;

            txtbox_username.Enabled = false;
            txtbox_username.Text = _users.username;
            txtbox_name.Text = _users.name;
            txtbox_email.Text = _users.email;
            txtbox_password.Text = _users.password;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(isNewData) _users = new Users();
            _users.username = txtbox_username.Text;
            _users.email = txtbox_email.Text;
            _users.password = txtbox_password.Text;
            _users.date_register = DateTime.Now.ToString("dd-MM-yyyy");
            _users.name = txtbox_name.Text;
            if(checkbox_Admin.Checked)
            {
                _users.status = "admin";
            } else
            {
                _users.status = "user";
            }

            int result = 0;

            if (isNewData)
            {
                result = _userControl.addUser(_users);
                if(result> 0)
                {
                    OnCreate(_users);

                    txtbox_name.Clear();
                    txtbox_username.Clear();
                    txtbox_email.Clear();
                    txtbox_password.Clear();
                    checkbox_Admin.Checked = false;

                    txtbox_name.Focus();

                }
            } else
            {
                result = _userControl.updateUser(_users);
                if(result> 0)
                {
                    OnUpdate(_users);
                    this.Close();
                }
            }
            
        }
    }
}
