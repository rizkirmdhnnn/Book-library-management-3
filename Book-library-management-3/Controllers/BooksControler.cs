using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Models.Repository;
using Book_library_management_3.Models.Context;

namespace Book_library_management_3.Controllers
{
    public class BooksControler
    {
        private BooksRepository _repository;
        
        public int addBook(Books book)
        {
            int result = 0;

            if (string.IsNullOrEmpty(book.isbn))
            {
                MessageBox.Show("Isbn cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(book.title))
            {
                MessageBox.Show("Title cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }


            if (string.IsNullOrEmpty(book.writter))
            {
                MessageBox.Show("Writter cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(book.genre))
            {
                MessageBox.Show("Genre cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(book.publisher))
            {
                MessageBox.Show("Publisher cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (book.stocks == default(int))
            {
                MessageBox.Show("Stocks cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            using(DbContext context = new DbContext())
            {
                _repository = new BooksRepository(context);
                result = _repository.addBook(book);

            }

            return result;
        }

    }
}
