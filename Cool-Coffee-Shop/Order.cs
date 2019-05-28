using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class Order
    {
        private static int orderCounter = 1000;
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public List<OrderLine> OrderList { get; set; }
        public double SubTotal { get; set; }
        public double TotalOrder { get; set; }
        private static readonly double TaxRate = 0.06;



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


        public double CalculateTotal(List<OrderLine> OrderList)
        {
            double total = CalculateSubTotal(OrderList) + CalculateTaxRate(OrderList);
            return total;
        }

        public double CalculateSubTotal(List<OrderLine>OrderList)
        {
            double subTotal = 0;
            foreach (var itemLine in OrderList)
            {
                double costOfItems = itemLine.Qty * itemLine.Item.Price;
                subTotal += costOfItems;
            }
            return subTotal;
        }

        public double CalculateTaxRate(List<OrderLine> OrderList)
        {
            return CalculateSubTotal(OrderList) * TaxRate;
        }




        public void Pay()
        {
            CalculateTotal(OrderList);

            // Choose Payment type. Switch to Specific payment process.
            while (true)
            {
                //if (Enum.TryParse(typeof(PaymentType), Console.ReadLine(), out PaymentType input))
                // get input of type PaymentType
                var input = PaymentType.Cash;
                {
                    switch (input)
                    {
                        case PaymentType.Cash:
                            PayCash();
                            return;
                        case PaymentType.Credit:
                            PayCredit();
                            return;
                        case PaymentType.Check:
                            PayCheck();
                            return;
                        default:
                            Console.WriteLine("Unknown Payment Type.");
                            break;
                    }
                }
                Console.Write("Input error: Please try again: ");
            }
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
        //public void PrintReceipt()
        //{
        //    //At the end, display a receipt with all items ordered, subtotal, grand total, and
        //    //appropriate payment info.
        //    Console.WriteLine($"");
        //}

        public void PrintReceipt(List<OrderLine> OrderList, double payment)
        {
            StringBuilder receipt = new StringBuilder("");
            Console.WriteLine("--- Receipt ---");
            foreach (var itemLine in OrderList)
            {
                Console.WriteLine
                (
                    "{0} {1} ${2} ea. ${3}",
                    itemLine.Item.Name,
                    itemLine.Qty,
                    itemLine.Item.Price,
                    itemLine.Item.Price * itemLine.Qty
                );
            }
            //var subTotal = CalculateSubTotal(OrderList);
            //var salesTax = CalculateTaxRate(OrderList);
            //var total = CalculateTotal(OrderList);
            //Console.WriteLine("Subtotal: ${0:0.00}", subTotal);
            //Console.WriteLine("Tax: ${0:0.00}", salesTax);
            //Console.WriteLine("Total: ${0:0.00}", total);
            //Console.WriteLine("Payment: ${0:0.00}", payment);
            //decimal change = processPayment(total, payment);
        }
    }
}
