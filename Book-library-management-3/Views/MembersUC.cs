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
        public MembersUC()
        {
            _usersControler = new UsersControler();
            InitializeComponent();
            InitializeListView();
            loadData();
        }


        private void loadData()
        {
            txt_total.Text  = _usersControler.getTotalMembers().ToString();
        }
        private void InitializeListView()
        {
            lv_Members.View = System.Windows.Forms.View.Details;
            lv_Members.FullRowSelect = true;
            lv_Members.GridLines = true;
            lv_Members.Columns.Add("", 0, HorizontalAlignment.Right);
            lv_Members.Columns.Add("Username", 180, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Password",  110, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Name", 210, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Email", 100, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Status", 110, HorizontalAlignment.Left);
            lv_Members.Columns.Add("Date Register", 100, HorizontalAlignment.Left);
        }
    }
}
