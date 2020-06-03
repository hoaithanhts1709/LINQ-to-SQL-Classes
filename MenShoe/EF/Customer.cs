using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenShoe.EF
{
    public class Customer
    {
        public long CustomerID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}