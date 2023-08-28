using BusinessAutomation.Models.EntityModels;
using BusinessAutomation.Models.UtilitysModels;
using BusinessAutomationApp.Database;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;


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
       
        public ICollection<Product> SearchProduct(ProductSearch productSearch)
        {
            var searchKey = productSearch.SearchKey;

            var products = db.Products.Include(b => b.Brand).AsQueryable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                products = products.Where(p => p.Name.ToLower().Contains(searchKey.ToLower())
                            || p.Description.ToLower().Contains(searchKey.ToLower())
                            || p.Brand.BrandName.ToLower().Contains(searchKey.ToLower()));
            }
            if (productSearch.ToPrice !=null)
            {
                products = products.Where(p => p.SalesPrice > productSearch.ToPrice);
            }
            if(productSearch.FromPrice !=null)
            {
                products = products.Where(p => p.SalesPrice <= productSearch.FromPrice);
            }
            return products.ToList();
        }
    }
}
