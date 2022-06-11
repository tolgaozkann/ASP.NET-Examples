using System;
using System.Collections.Generic;

namespace example2.Entities.Northwind
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
