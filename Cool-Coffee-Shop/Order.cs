using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
        public decimal PaymentGeneric { get; set; } 
        public int PaymentType { get; set; }
        public static readonly double TaxRate = 0.06;

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
        public void RemoveFromAnOrder()
        {
            if(OrderList.Count == 0)
            {
                Console.WriteLine("Error: No items in cart.\nPress any key to continue.");
                Console.ReadKey();
                return;
            }
            if (OrderList.Count == 1)
            {
                OrderList.Remove(OrderList[0]);
                Console.WriteLine("Item removed from cart.\nPress any key to continue.");
                Console.ReadKey();
                return;
            }
            Console.Write($"Which item would you like to remove? (1-{OrderList.Count}): ");
            OrderList.Remove(OrderList[Common.GetInt(1, OrderList.Count) - 1]);
        }
        public void CalculateTotal()
        {
            CalculateSubTotal();
            TotalOrder = SubTotal + CalculateTaxRate();
        }
        public void CalculateSubTotal()
        {
            SubTotal = 0;
            foreach (var itemLine in OrderList)
            {
                double costOfItems = itemLine.Qty * itemLine.Item.Price;
                SubTotal += costOfItems;
            }
        }
        public double CalculateChange(double total, double payment)
        {
            TotalOrder = total;
            return payment - total;
        }
        public double CalculateTaxRate()
        {
            return SubTotal * TaxRate;
        }
        public void Pay()
        {
            if(OrderList.Count == 0)
            {
                Console.WriteLine("Nothing in cart! Returning to main menu: ");
                Console.ReadKey();
                return;
            }

            CalculateTotal();
            TotalOrder = Math.Round(TotalOrder, 2);

            var header = new HeaderBar(64);
            header.DrawCheckout(this);
            header.DrawPaymentOptions();
             
            while (true)
            {
                var paymentType = Common.GetInt(1, 3);

                PaymentType = paymentType;
                switch (paymentType)
                {
                    case 1:
                        PayCash();
                        return;
                    case 2:
                        PayCredit();
                        return;
                    case 3:
                        PayCheck();
                        return;
                    default:
                        Console.WriteLine("Unknown Payment Type.");
                        break;
                }
                Console.Write("Input error: Please try again: ");
            }
        }
        public void PayCash()
        {
            double userPayCash, orderChange;
            Console.Write("How much cash do you offer? ");
            userPayCash = GetCash();
            Console.WriteLine($"Cash Received: ${userPayCash}");
            while (userPayCash < TotalOrder)
            {
                Console.WriteLine("Insufficient funds.");
                userPayCash = GetCash();
            }
            if (userPayCash >= TotalOrder)
            {
                PaymentGeneric = (decimal)userPayCash;
                orderChange = userPayCash - TotalOrder;
                Console.WriteLine($"Total Change: $" + orderChange);
                Console.WriteLine($"Printing Receipt:");
                Console.ReadKey();

                PrintReceipt();
                Console.ReadKey();
            }
        }
        private double GetCash()
        {
            while (true)
            {
                if(double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                Console.Write("Input Error. Please try again: ");
            }
        }
        public void PayCredit()
        {
            string userCCNumber, userCVV, userCCDate;
            Console.Write("Enter the 16 Digit Card Number: ");
            var cardCheck = new Regex(@"^([\-\s]?[0-9]{4}){4}$");
            userCCNumber = Console.ReadLine();
            PaymentGeneric = decimal.Parse(userCCNumber);
            while (!cardCheck.IsMatch(userCCNumber))
            {
                Console.Write($"\nInvalid card number. \nEnter the 16 Digit Card Number: ");
                userCCNumber = Console.ReadLine();
            }
            Console.Write("\nEnter Credit Card Expiration Date(mm/yyyy): ");
            var dateCheck = new Regex(@"^(0[1-9]|1[0-2])([/])(20[0-9]{2})$");
            userCCDate = Console.ReadLine();
            while (!dateCheck.IsMatch(userCCDate))
            {
                Console.Write("\nInvalid date.  \nEnter the Expiration Date(mm/yyyy): ");
                userCCDate = Console.ReadLine();
            }
            Console.Write("\nEnter Credit Card CVV: ");
            var cvvCheck = new Regex(@"^\d{3}$");
            userCVV = Console.ReadLine();
            while (!cvvCheck.IsMatch(userCVV))
            {
                Console.Write("\nInvalid CVV.  \nEnter 3 Digit CVV located on the back of the card: ");
                userCVV = Console.ReadLine();
            }
            Console.WriteLine("Payment accepted. Printing receipt.");
            Console.ReadKey();
            PrintReceipt();
            Console.ReadKey();
        }
        public void PayCheck()
        {
            string checkNumber;
            Console.Write("Enter the 4 digit check number: ");
            var checkVerify = new Regex(@"^\d{4}$");
            checkNumber = Console.ReadLine();
            PaymentGeneric = decimal.Parse(checkNumber);
            while (!checkVerify.IsMatch(checkNumber))
            {
                Console.Write("Invalid Entry. \nEnter the 4 digit check number: ");
                checkNumber = Console.ReadLine();
            }
            Console.WriteLine("Your check payment has cleared. Printing receipt.");
            Console.ReadKey();
            PrintReceipt();
            Console.ReadKey();
        }
        public void Cancel()
        {
            Console.WriteLine($"Order {OrderID} has been cancelled. Press any key to return to main menu.");
            Console.ReadKey();
        }
        public void PrintReceipt()
        {
            var receiptPrinter = new HeaderBar(64);
            receiptPrinter.PrintReceipt(this);
        }
    }
}