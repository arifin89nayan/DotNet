using BusinessAutomation.Models.EntityModels;
using BusinessAutomation.Models.UtilitysModels;
using BusinessAutomationApp.Database;
using BusinessAutomtion.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    public static void Main(string[] args)
    {
        BusinessAutomationDbContext db = new BusinessAutomationDbContext();
        ProductsRepository productsRepository = new ProductsRepository();
        BrandRepository brandRepository = new BrandRepository();
        CustomerRepository customerRepository = new CustomerRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        /*var customer = new Customer();
        {
            Name = "Rimon",
            Phone = "01792119633",
            Email = "Rimon@yahoo.com",
            Address = "Uttara Dhaka-1230"
        };*/
        //bool IsSuccess=customerRepository.Add(customer);
        var category = new Category()
        {
            CategoryName = "Phone",
            CategoryDescription = "Diffrent kind of Phone now in market"
        };
        //bool IsSuccess = categoryRepository.Add(category);
        //Customer Remove from database
        var customer = db.Customers.FirstOrDefault(c => c.Id ==2);
      
        if (customer!=null)
        {
            customerRepository.Remove(customer);
            Console.WriteLine("Customer remove!..");
        }

        
        /* var products = db.Products
             .Include(c=>c.Brand)
            .Where(c=>c.BrandId==1)
             .AsQueryable();*/
        //Linq Classic 
        /* var products = from p in db.Products
                        where p.SalesPrice > 10000 && p.SalesPrice <= 15000
                        select p;*/
        //Linq
        //var products = db.Products.Where(c => c.SalesPrice > 10000 && c.SalesPrice <= 15000);
        //Joining
        /* var products=from p in db.Products join
                      b in db.Brands on p.BrandId equals b.Id
                      select new{p.Name,p.SalesPrice,b.BrandName };*/
        //var brands = db.Brands.Include(p=>p.Products.Where(x=>x.SalesPrice>10000 && x.SalesPrice<=15000));
        //var products = db.Products.Include(b => b.Brand).Where(x => x.SalesPrice > 10000 && x.SalesPrice <= 15000);
        /*var exitingProducts = from p in db.Products
                              join b in db.Brands on p.BrandId equals b.Id
                              where (p.SalesPrice > 10000 && p.SalesPrice <= 15000)
                              select new {p.Name, p.Brand.BrandName,p.SalesPrice };
                              //from prodbrand in pb.DefaultIfEmpty()
                             // .Where(p=>p.SalesPrice > 10000 && p.SalesPrice <= 15000);
                            //select new Product() { Name=p.Name,Id=p.Id,SalesPrice=p.SalesPrice,Brand=prodbrand};*/

        /*Console.WriteLine("Enter Search Key...");
        string searchKey = Console.ReadLine();
        double? fromprice= null;
        double? toprice= 10000;
        var searchValue = new ProductSearch()
        {
            SearchKey = searchKey,
            ToPrice=toprice,
            FromPrice=fromprice
        };
        var exitingProducts = productsRepository.SearchProduct(searchValue);

       if (exitingProducts != null)
        {
            foreach(var product in exitingProducts)
            {
                Console.WriteLine(product.GetInfo());
            }
            
        }*/
        /* var exitbrand = brandRepository.GetById(1);
         if (exitbrand == null)
         {
             throw new Exception("Brand Not Found");
         }
         exitbrand.BrandName = "Samsung";
         brandRepository.Db = db;
         bool isSuccess =brandRepository.Update(exitbrand);

         if (isSuccess)
         {
             Console.WriteLine("Save Successfull!");
         }
        */
    }
}

