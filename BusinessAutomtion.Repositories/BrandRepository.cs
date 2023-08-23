using BusinessAutomation.Models.EntityModels;
using BusinessAutomationApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAutomtion.Repositories
{
    public class BrandRepository
    {
        
            BusinessAutomationDbContext db;
            public BrandRepository()
            {
                db = new BusinessAutomationDbContext();
            }
        public BusinessAutomationDbContext Db
        {
            get { return db; }
            set { db = value; }
        }

        public bool Add(Brand brand)
            {
                db.Brands.Add(brand);
                return db.SaveChanges() > 0;
            }

            public Brand GetById(int id)
            {

                var exitingProduct = db.Brands.FirstOrDefault(p => p.Id == id);
                return exitingProduct;


            }

            public bool Update(Brand brand)
            {
                db.Brands.Update(brand);
                return db.SaveChanges() > 0;
            }
        }
    
}
