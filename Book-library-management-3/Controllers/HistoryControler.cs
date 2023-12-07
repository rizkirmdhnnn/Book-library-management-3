using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_library_management_3.Models.Repository;
using Book_library_management_3.Models.Entity;
using Book_library_management_3.Models.Context;
using System.Web.Management;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Book_library_management_3.Controllers
{
    public class HistoryControler
    {
        private HistoryRepository _repository;
        
        public List<History> getAllHistory()
        {
            List<History> list = new List<History>();

            using(DbContext context = new DbContext())
            {
                _repository = new HistoryRepository(context);
                
                list = _repository.getAllHistory();
            }

            return list;
        }

        public List<History> getHistoryByUsername(History history)
        {

            List<History> list = new List<History>();

            using (DbContext context = new DbContext())
            {
                _repository = new HistoryRepository(context);

                list = _repository.getHistoryByUsername(history);
            }

            return list;
        }

        public int addHistory(History history)
        {
            int result = 0;
            using(DbContext context = new DbContext())
            {
                _repository = new HistoryRepository(context);
                result = _repository.addHistory(history);
            }
            return result;
        }
    }
}
