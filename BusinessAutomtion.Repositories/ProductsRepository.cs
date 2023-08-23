using BusinessAutomation.Models.EntityModels;
using BusinessAutomationApp.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BusinessAutomtion.Repositories
{
    public class ProductsRepository
    {
        BusinessAutomationDbContext db;
        public ProductsRepository()
        {
                db = new BusinessAutomationDbContext();
        }
        public BusinessAutomationDbContext Db
        {
            get { return db; }
            set { db = value; }
        }
        public bool Add(Product products)
        {
            db.Products.Add(products);
            return db.SaveChanges()>0;
        }

        public Product GetById(int id)
        {
           
                var exitingProduct = db.Products.FirstOrDefault(p => p.Id == id);
                return exitingProduct;

            
        }

        public bool Update(Product products)
        {
            db.Products.Update(products);
            return db.SaveChanges() > 0;
        }
    }
}
