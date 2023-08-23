using BusinessAutomation.Models.EntityModels;
using BusinessAutomationApp.Database;
using BusinessAutomtion.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    public static void Main(string[] args)
    {
        ProductsRepository productsRepository = new ProductsRepository();
        BrandRepository brandRepository = new BrandRepository();

        BusinessAutomationDbContext db =new BusinessAutomationDbContext();
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
        var products=from p in db.Products join
                     b in db.Brands on p.BrandId equals b.Id
                     select new{p.Name,p.SalesPrice,b.BrandName };

       if(products != null)
        {
            foreach(var product in products)
            {
                Console.WriteLine(product);
            }
            
        }
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

