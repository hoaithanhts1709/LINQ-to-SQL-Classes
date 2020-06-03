using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenShoe.EF
{
    public class Product
    {
        public long ProductID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Detail { get; set; }
        public string Email { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Image { get; set; }
        public long? CategoryID { get; set; }
        public long? ProductCategoryID { get; set; }
    }
}