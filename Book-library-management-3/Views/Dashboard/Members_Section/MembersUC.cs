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
    public partial class MembersUC : UserControl
    {
        private UsersControler _usersControler;
        List<Users> _user = new List<Users>();
        public MembersUC()
        {
            _usersControler = new UsersControler();
            InitializeComponent();
            InitializeListView();
            loadData();
        }


        private void loadData()
        {
            lv_Members.Items.Clear();
            txt_members.Text  = _usersControler.getTotalMembers().ToString();
            txt_admin.Text  = _usersControler.getTotalAdmin().ToString();
            _user = _usersControler.getUsers();

            foreach (Users _users in _user)
            {
                var item = new ListViewItem();
                item.SubItems.Add(_users.username);
                item.SubItems.Add(_users.password);
                item.SubItems.Add(_users.name);
                item.SubItems.Add(_users.email);
                item.SubItems.Add(_users.status);
                item.SubItems.Add(_users.date_register);
                lv_Members.Items.Add(item);

            }
        }
        private void InitializeListView()
        {
            lv_Members.View = System.Windows.Forms.View.Details;
            lv_Members.FullRowSelect = true;
            lv_Members.GridLines = true;
            lv_Members.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_Members.Columns.Add("Username", 110, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Password",  110, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Name", 190, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Email", 170, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Status", 110, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Date Register", 100, HorizontalAlignment.Left);
        }

        private void txtbox_username_TextChanged(object sender, EventArgs e)
        {
            lv_Members.Items.Clear();
            Users users = new Users();
            users.username = txtbox_username.Text;
            _user = _usersControler.getByUsername(users);

            foreach (Users _users in _user)
            {
                var item = new ListViewItem();
                item.SubItems.Add(_users.username);
                item.SubItems.Add(_users.password);
                item.SubItems.Add(_users.name);
                item.SubItems.Add(_users.email);
                item.SubItems.Add(_users.status);
                item.SubItems.Add(_users.date_register);
                lv_Members.Items.Add(item);

            }
        }
    }
}
