﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAutomation.Models.EntityModels
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
