using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Models.Repository;
using Book_library_management_3.Models.Context;
using Book_library_management_3.Views;

namespace Book_library_management_3.Controllers
{
    public class UsersControler
    {
        private usersRepository _repository;
        public string checkUserAdmin(Users users)
        {
            string result = "";

            if (string.IsNullOrEmpty(users.username) && string.IsNullOrEmpty(users.password))
            {
                MessageBox.Show("Username and Password cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }

            if (string.IsNullOrEmpty(users.username))
            {
                MessageBox.Show("Username cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            if (string.IsNullOrEmpty(users.password))
            {
                MessageBox.Show("Password cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }

            using(DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                result = _repository.checkUserAdmin(users);
            }

            if(result == "")
            {
                MessageBox.Show("Data not found, login failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                MessageBox.Show("Data found, login successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DashboardPage dashboardPage = new DashboardPage(result);
                dashboardPage.Show();
            }

            return result;
        }

        public int addUser(Users users)
        {
            int result = 0;

            if (string.IsNullOrEmpty(users.username))
            {
                MessageBox.Show("Username cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(users.password))
            {
                MessageBox.Show("Password cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(users.name))
            {
                MessageBox.Show("Name cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(users.email))
            {
                MessageBox.Show("Email cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(users.status))
            {
                MessageBox.Show("Status cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(users.date_register))
            {
                MessageBox.Show("Date cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            using(DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                result = _repository.addUser(users);
                
            }

            if(result == 0)
            {
                MessageBox.Show("Eror", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else
            {
                MessageBox.Show("Data added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            return result;
        }

        public int deleteUser(Users users)
        {
            int result = 0;

            using(DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                result = _repository.deleteUser(users);
            }

            return result;

        }

        public int updateUser(Users users)
        {
            int result = 0;
            using(DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                result = _repository.updateUser(users);
            }

            return result;
        }
        public List<Users> getUsers()
        {
            List<Users> list = new List<Users>();
            using(DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                list = _repository.getUser();
            }

            return list;
        }

        public List<Users> getUserAdmin()
        {
            List<Users> list = new List<Users>();
            using (DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                list = _repository.getUserAdmin();
            }

            return list;
        }

        public int getTotalMembers()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                result = _repository.getTotalMembers();
            }

            return result;
        }

        public int getTotalAdmin()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                result = _repository.getTotalAdmin();
            }

            return result;
        }

        public List<Users> getRecentMembers()
        {
            List<Users> list = new List<Users>();

            using (DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                list = _repository.getRecentMembers();
            }

            return list;
        }

        public List<Users> getByUsername(Users users)
        {
            List<Users> list = new List<Users>();

            using (DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                list = _repository.getByUsername(users);
            }

            return list;
        }

        public AutoCompleteStringCollection getUsername()
        {
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

            using (DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                autoComplete = _repository.getUsername();
            }

            return autoComplete;
        }

        public string getEmailByUsername(string name)
        {
            string result = "";
            using (DbContext context = new DbContext())
            {
                _repository = new usersRepository(context);
                result = _repository.getEmailByUsername(name);
            }
            return result;
        }
    }
}
