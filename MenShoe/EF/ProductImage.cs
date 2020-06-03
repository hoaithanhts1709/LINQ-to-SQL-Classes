using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenShoe.EF
{
    public class ProductImage
    {
        public long ProductImageID { get; set; }
        public string TImageDetail { get; set; }
        public long? ProductID { get; set; }

    }
}