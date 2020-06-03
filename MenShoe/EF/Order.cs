using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenShoe.EF
{
    public class Order
    {
        public long OrderID { get; set; }
        public long? CustomerID { get; set; }
        public int? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
    }
}