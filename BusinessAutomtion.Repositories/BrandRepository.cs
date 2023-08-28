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
    public class BrandRepository : BaseRepository<Brand>
    {
        
            BusinessAutomationDbContext db;
            public BrandRepository()
            {
                db = new BusinessAutomationDbContext();
                _db = db;
            }
            public BusinessAutomationDbContext Db
            {
                get { return db; }
                set { db = value; }
            }
            public ICollection<Brand> GetAll()
            {
                return db.Brands.ToList();
            }

        }
    
}
