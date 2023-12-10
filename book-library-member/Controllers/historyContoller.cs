using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_library_member.Models.repository;
using book_library_member.Models.entity;
using book_library_member.Models.context;

namespace book_library_member.Controllers
{
    public class historyContoller
    {
        private historyRepository _repository;
        
        public List<history> getHistoryByUsername(history history)
        {
            List<history> list = new List<history>();
            using(DbContext context = new DbContext())
            {
                _repository = new historyRepository(context);
                list = _repository.getHistoryByUsername(history);
            }
            return list;
        }
    }
}
