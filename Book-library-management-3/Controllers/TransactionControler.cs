using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_library_management_3.Models.Repository;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Models.Context;
using System.Windows.Forms;

namespace Book_library_management_3.Controllers
{

    public class TransactionControler
    {
        private transactionsRepository _repository;

        public int borrowingBook(Transactions transactions)
        {
            int result = 0;

            if (string.IsNullOrEmpty(transactions.isbn))
            {
                MessageBox.Show("ISBN cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(transactions.username))
            {
                MessageBox.Show("Username cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(transactions.status))
            {
                MessageBox.Show("Status cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(transactions.date))
            {
                MessageBox.Show("Date cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            using(DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                result = _repository.borrowingBook(transactions);
            }

            return result;
        }

        public int getTransaction_id()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                result = _repository.getTransaction_id();
            }

            return result;
        }
        
        public int returnBook(Transactions transactions)
        {
            int result = 0;

            if (transactions.transactions_id == default(int))
            {
                MessageBox.Show("TransactionID cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(transactions.isbn))
            {
                MessageBox.Show("ISBN cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(transactions.username))
            {
                MessageBox.Show("Username cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(transactions.status))
            {
                MessageBox.Show("Status cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                result = _repository.returnBook(transactions);
            }

            return result;
        }
    
        public List<Transactions> getAllTransactions()
        {
            List<Transactions> list = new List<Transactions>();

            using (DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                list = _repository.getAllTransactions();
            }

            return list;
        }

        public List<Transactions> getTransactionsByUsername(string username)
        {
            List<Transactions> list = new List<Transactions>();

            using (DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                list = _repository.getTransactionByUsername(username);
            }

            return list;
        }

        public List<Transactions> getBorrowingByUsername(string username)
        {
            List<Transactions> list = new List<Transactions>();

            using (DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                list = _repository.getBorrowingByUsername(username);
            }

            return list;
        }

        public int getTotalBorrowingBook()
        {
            int result = 0;
            using(DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                result = _repository.getTotalBorrowingBook();
            }
            return result;
        }
        public int getTotalReturnedBook()
        {
            int result = 0;
            using(DbContext context = new DbContext())
            {
                _repository = new transactionsRepository(context);
                result = _repository.getTotalReturnedBook();
            }
            return result;
        }


    }
}
