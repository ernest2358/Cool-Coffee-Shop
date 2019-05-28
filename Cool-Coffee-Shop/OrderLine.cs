using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class OrderLine
    {
        public Product Item { get; set; }
        public int Qty { get; set; }
        //public string Customization { get; set; }

        public OrderLine(Product product, int qty)
        {
            Item = product;
            Qty = qty;
        }
    }
}
