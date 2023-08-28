using BusinessAutomation.Models.EntityModels;
using BusinessAutomationApp.Database;
using BusinessAutomtion.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAutomtion.Repositories
{
    public class CustomerRepository :BaseRepository<Customer>
    {
        BusinessAutomationDbContext db;
        public CustomerRepository()
        {
            db = new BusinessAutomationDbContext();
            _db = db;
        }
    }
}
