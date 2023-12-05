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
using Book_library_management_3.Views.Dashboard.Members_Section;

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

        private void btn_add_Click(object sender, EventArgs e)
        {
            popUp_Members popUp = new popUp_Members("Create Account", _usersControler);
            popUp.OnCreate += OnCreateEventHandler;
            popUp.Show();
        }

        private void OnCreateEventHandler(Users users)
        {
            _user.Add(users);
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(users.username);
            item.SubItems.Add(users.password);
            item.SubItems.Add(users.name);
            item.SubItems.Add(users.email);
            item.SubItems.Add(users.status);
            item.SubItems.Add(users.date_register);
            lv_Members.Items.Add(item);
        }

        private void OnUpdateEventHandler(Users users)
        {
            int index = lv_Members.SelectedIndices[0];
            ListViewItem itemRow = lv_Members.Items[index];
            itemRow.SubItems[1].Text = users.username;
            itemRow.SubItems[2].Text = users.password;
            itemRow.SubItems[3].Text = users.name;
            itemRow.SubItems[4].Text = users.email;
            itemRow.SubItems[5].Text = users.status;
            itemRow.SubItems[6].Text = users.date_register;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lv_Members.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Do you want to delete the account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Users users = _user[lv_Members.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = _usersControler.deleteUser(users);
                    if (result > 0) loadData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Account has not been selected", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (lv_Members.SelectedItems.Count > 0)
            {
                Users users = _user[lv_Members.SelectedIndices[0]];
                popUp_Members popUp_Members = new popUp_Members("Edit book data", users, _usersControler);
                popUp_Members.OnUpdate += OnUpdateEventHandler;
                popUp_Members.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan",
               MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }
    }
}
