using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class HeaderBar
    {
        public int HeaderWidth { get; set; }

        public HeaderBar(int width)
        {
            HeaderWidth = width;
        }

        public void DrawHeader()
        {
            var name = "Cool Coffee Shop";
            Console.WriteLine($"+{new String('-', HeaderWidth - 2)}+");
            Console.WriteLine($"|{new String(' ', (HeaderWidth - name.Length) / 2 - 1)}{name}{new String(' ', (HeaderWidth - name.Length) / 2 - 1)}|");
            Console.WriteLine($"+{new String('-',HeaderWidth-2)}+");
        }
        public void DrawHeader(Order order)
        {
            Console.WriteLine($"+{new String('-', HeaderWidth - 2)}+");
            Console.WriteLine($"|{new String(' ', (HeaderWidth - order.OrderID.ToString().Length) / 2 - 5)}Order # {order.OrderID}{new String(' ', (HeaderWidth - order.OrderID.ToString().Length) / 2 - 5)}|");
            Console.WriteLine($"+{new String('-', HeaderWidth - 2)}+");
            Console.WriteLine($"|{new String(' ', HeaderWidth - 2)}|");
            Console.WriteLine($"|   Cart({order.OrderList.Count}){new String(' ', HeaderWidth - 25 - order.OrderList.Count.ToString().Length - order.SubTotal.ToString().Length)}Subtotal: ${order.SubTotal}   |");
            Console.WriteLine($"+{new String('-', HeaderWidth - 2)}+");
        }
        public void DrawMenu(List<Product> productList)
        {
            for (var i = 1; i <= productList.Count; i++)
            {
                Console.WriteLine($"| {i} - {productList[i - 1].Name} {new String('.', HeaderWidth - 10 - productList[i - 1].Name.Length - productList[i - 1].Price.ToString().Length - i.ToString().Length)} ${productList[i - 1].Price} |");
            }
            Console.WriteLine($"+{new String('-', HeaderWidth - 2)}+");

        }
    }
}
