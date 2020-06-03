using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenShoe.EF
{
    public class OrderDetails
    {
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        public long SizeID { get; set; }
        public long ColorID { get; set; }
        public int? Quantity { get; set; }
    }
}