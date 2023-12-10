using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_library_member.Models.context;
using book_library_member.Models.entity;
using book_library_member.Models.repository;

namespace book_library_member.Controllers
{
    public class usersController
    {
        private usersRepository _usersRepository;

        public string checkUser(users _users)
        {
            string result = "";
            if (string.IsNullOrEmpty(_users.username) && string.IsNullOrEmpty(_users.password))
            {
                MessageBox.Show("Username and Password cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }

            if (string.IsNullOrEmpty(_users.username))
            {
                MessageBox.Show("Username cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            if (string.IsNullOrEmpty(_users.password))
            {
                MessageBox.Show("Password cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }

            using (DbContext dbContext = new DbContext())
            {
                _usersRepository = new usersRepository(dbContext);
                result = _usersRepository.checkUser(_users);
            }

            return result;
        }
    }
}
