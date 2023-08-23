using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAutomation.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SalesPrice { get; set; }
        public virtual Brand Brand { get; set; }
        public int? BrandId { get; set; }
        public bool IsDeleted { get; set; }
        public string GetInfo()
        {
            var message= $"Name:{Name} Description:{Description} Price:{SalesPrice}";
            if(Brand != null)
            {
                message += $"Brand Name:{Brand.BrandName}";
            }
            return message ;
        }


    }
}
