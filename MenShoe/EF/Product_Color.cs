using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenShoe.EF
{
    public class Product_Color
    {
        public long ProductColorID { get; set; }
        public long? ColorID { get; set; }
        public long? ProductID { get; set; }
    }
}