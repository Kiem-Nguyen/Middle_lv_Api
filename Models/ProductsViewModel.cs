using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodFunday.Models
{
    public class ProductsViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double? price { get; set; }
        public string Images { get; set; }
    }
}