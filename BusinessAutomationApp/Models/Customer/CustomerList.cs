using System.Reflection;

namespace BusinessAutomationApp.Models.Customer
{
    public class CustomerList
    {
        public List<CustomerCreate> Customers { get; set; }
      public List<BusinessAutomation.Models.EntityModels.Customer> customer { get; set; }
        public Company company { get; set; }
    }
}
