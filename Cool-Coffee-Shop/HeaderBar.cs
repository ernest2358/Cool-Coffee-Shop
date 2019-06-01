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
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
            Console.WriteLine($"|{new string(' ', (HeaderWidth - name.Length) / 2 - 1)}{name}{new string(' ', (HeaderWidth - name.Length) / 2 - 1)}|");
            Console.WriteLine($"+{new string('-',HeaderWidth-2)}+");
        }
        public void DrawMainMenuOptions()
        {
            var left = new string($"|       1 - Create an Order");
            var right = new string($"|");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            left = new string($"|       2 - Add a new product to menu");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            left = new string($"|       3 - See the menu");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            left = new string($"|       4 - Exit Coffee Shop App");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
        }
        public void DrawOrderMenuOptions()
        {
            var left = new string($"|       1 - Add an item to order");
            var right = new string($"|");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            left = new string($"|       2 - Remove an item from order");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            left = new string($"|       3 - Checkout");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            left = new string($"|       4 - Cancel order");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            left = new string($"|       5 - Show Cart");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
        }
        public void DrawHeader(Order order)
        {
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
            Console.WriteLine($"|{new string(' ', (HeaderWidth - order.OrderID.ToString().Length) / 2 - 5)}Order # {order.OrderID}{new string(' ', (HeaderWidth - order.OrderID.ToString().Length) / 2 - 5)}|");
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
            Console.WriteLine($"|{new string(' ', HeaderWidth - 2)}|");
            var left = new string($"|   Cart({GetCartItemCount(order)})");
            var right = new string($"Subtotal: ${order.SubTotal}   |");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
        }
        private int GetCartItemCount(Order order)
        {
            var counter = 0;
            foreach(var line in order.OrderList)
            {
                counter += line.Qty;
            }
            return counter;
        }
        public void DrawMenu(List<Product> productList)
        {
            for (var i = 1; i <= productList.Count; i++)
            {
                var left = new string($"| {i} - {productList[i - 1].Name} ");
                var right = new string($" ${productList[i - 1].Price} |");
                Console.WriteLine($"{left}{new string('.', HeaderWidth - left.Length - right.Length)}{right}");
            }
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
        }
        public void DrawCart(Order order)
        {
            for (var i = 1; i <= order.OrderList.Count; i++)
            {
                if (order.OrderList[i - 1].Qty == 1)
                {
                    var left = new string($"| {i} - {order.OrderList[i - 1].Item.Name} ");
                    var right = new string($" ${order.OrderList[i - 1].Item.Price}    |");
                    Console.WriteLine($"{left}{new string('.', HeaderWidth - left.Length - right.Length)}{right}");
                }
                else
                {
                    var left = new string($"| {i} - {order.OrderList[i - 1].Item.Name} ");
                    var right = new string($"|");
                    Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");

                    left = new string($"|     ---    {order.OrderList[i - 1].Qty}x {order.OrderList[i - 1].Item.Price}ea ");
                    right = new string($" ${order.OrderList[i - 1].Item.Price * order.OrderList[i - 1].Qty}    |");
                    Console.WriteLine($"{left}{new string('.', HeaderWidth - left.Length - right.Length)}{right}");
                }
            }
            Console.WriteLine($"|{new string(' ', HeaderWidth - 2)}|");
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
        }
        public void DrawCheckout(Order order)
        {
            Console.Clear();
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");
            var left = new string($"Checkout: Order # {order.OrderID}");
            var right = new string($"|");
            Console.WriteLine($"|{new string(' ', (HeaderWidth - left.Length) / 2)}{left}{new string(' ', (HeaderWidth - left.Length) / 2)}| ");
            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");

            DrawCart(order);
            
            Console.WriteLine($"|{new string(' ', HeaderWidth - 2)}|");

            left = new string($"|");
            right = new string($"Subtotal: ${order.SubTotal}   |");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");

            right = new string($"Tax (MI: {Order.TaxRate * 100}%): ${Math.Round(order.SubTotal * Order.TaxRate, 2)}   |");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");

            right = new string($"Grand Total: ${order.TotalOrder}   |");
            Console.WriteLine($"{left}{new string(' ', HeaderWidth - left.Length - right.Length)}{right}");

            Console.WriteLine($"+{new string('-', HeaderWidth - 2)}+");

        }
    }
}