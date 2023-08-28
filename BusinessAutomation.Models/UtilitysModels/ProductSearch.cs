using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAutomation.Models.UtilitysModels
{
    public class ProductSearch
    {
        public double? ToPrice { get; set; }
        public double? FromPrice { get; set; }
        public string SearchKey { get; set; }
    }
}
