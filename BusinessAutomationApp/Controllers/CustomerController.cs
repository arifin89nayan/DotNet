
using BusinessAutomation.Models.EntityModels;
using BusinessAutomationApp.Database;
using BusinessAutomationApp.Models;
using BusinessAutomationApp.Models.Customer;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BusinessAutomationApp.Controllers
{
    public class CustomerController : Controller
    {
        BusinessAutomationDbContext db;
        public CustomerController()
            {
                db=new BusinessAutomationDbContext();

            }

        public static List<CustomerCreate> CustomerTable;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerCreate customer)
        {
            if(customer.Name!=null && customer.Phone.Length != 11)
            {
                ModelState.AddModelError("Phone", "Phone Number Must 11 Digit!");
            }
            
            if(ModelState.IsValid)
            {
                var entity = new Customer()
                {
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Email = customer.Email,
                };
                db.Customers.Add(entity);
                int sucessCount= db.SaveChanges();
                if(sucessCount>0)
                {
                    ViewBag.SuccessMessage = "Saved Successfully!";
                    return View("Success");
                }
               
            }
            return View();

        }
        [HttpGet]
        public IActionResult List()
        {
           var customers = db.Customers.ToList();
           
            
            var company = new Company()
            {
                companyIt="SC-01",
                companyName="Enlight Solution",
                companyLocation="Mirpur DOHS"

            };
            var customerListVM = new CustomerList()
            {
                company = company,
                customer = customers

            };
            return View(customerListVM);
            

        }
        public string CreateList(List<CustomerCreate> customers)
        {
            string message = "";
            foreach (var customer in customers)
            {
            
               message += $"Customer Name:{customer.Name} Phone Number {customer.Phone} \n";
            }
          return message;
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Id is not set for the Customer!";
                return View("Error");
            }
            var customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                ViewBag.ErrorMessage = $"Did not find any Customer with Id {id}";

                return View("Error");
            }
            var customerListVM = new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email,


            };

            return View(customerListVM);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {

            if (customer.Name == null|customer.Phone==null|customer.Email==null)
            {
                ViewBag.ErrorMessage = "Id is not set for the Customer!";
                return View("Error");
            }
            var cusUpdate = db.Customers.FirstOrDefault(x => x.Id==customer.Id);
           if(cusUpdate != null) 
            {
                cusUpdate.Name = customer.Name;
                cusUpdate.Phone = customer.Phone;
                cusUpdate.Email = customer.Email;
                int successCount = db.SaveChanges();
                if (successCount > 0)
                {
                    ViewBag.SuccessMessage = "Data Update Successfully!";
                    return View("Success");
                }
            };
            //db.Customers.Add(customerUpdate);
          
            
            return View("Error");
            
        }
        public IActionResult Remove(int id) 
        {
          
            var cusUpdate = db.Customers.FirstOrDefault(x => x.Id == id);
            if (cusUpdate != null)
            {
                db.Customers.Remove(cusUpdate);
                int successCount = db.SaveChanges();
                if (successCount > 0)
                {
                    ViewBag.SuccessMessage = "Data Delete Successfully!";
                    return View("Success");
                }

            }
                return View("Error");
        }

    }
}
