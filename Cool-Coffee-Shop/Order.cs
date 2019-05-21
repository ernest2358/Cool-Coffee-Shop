using System;
using System.Collections.Generic;

namespace Cool_Coffee_Shop
{
    public class Order
    {
        private static int orderCounter = 1000;
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public List<OrderLine> OrderList { get; set; }

        public Order()
        {
            orderCounter++;
            OrderID = orderCounter;

            OrderList = new List<OrderLine>();


        }
        public void AddToAnOrder(Product addedProduct, int qty)
        {
            OrderList.Add(new OrderLine(addedProduct, qty));
        }

        //public Product RemoveFromAnOrder()
        //{

        //}

        private void TotalOrder(float taxRate)
        {
            // Subtotal perhaps add these as properties of the class
            // Taxes
            // Grandtotal
        }

        public void Pay()
        {
            TotalOrder(0.06f);

            // Choose Payment type. Switch to Specific payment process.
        }
        public void PayCash() { }
        public void PayCredit() { }
        public void PayCheck() { }

        public void Cancel()
        {
            Console.WriteLine($"Order {OrderID} has been cancelled. Press any key to return to main menu.");
            Console.ReadKey();
            // return to main menu
        }
        public void PrintReceipt()
        {

        }
    }
}
