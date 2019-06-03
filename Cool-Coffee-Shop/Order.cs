﻿using System;
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
        public double PaymentDetail { get; set; }

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
                Console.WriteLine($"Please select an item from 1-{OrderList.Count}");
                var remove = int.Parse(Console.ReadLine());
                if (remove > OrderList.Count)
                {
                    Console.WriteLine("Your selection is invalid please press enter to return to your order.");
                    Console.ReadKey();
                    return;
                }
                var chosenRemoval = OrderList[remove - 1];
                OrderList.Remove(chosenRemoval);
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
            CalculateTotal();
            TotalOrder = Math.Round(TotalOrder, 2);

            var header = new HeaderBar(64);
            header.DrawCheckout(this);
            while (true)
            {
                Console.WriteLine($"How would you like to pay for your order? Please select options 1-3: \n1 - Cash, 2 - Credit/Debit, 3 - Check");

                var paymentType = int.TryParse(Console.ReadLine(), out int result);
                PaymentType = result;
                switch (result)
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
                Console.ReadKey();
            }
            if (userPayCash >= TotalOrder)
            {
                orderChange = userPayCash - TotalOrder;
                Console.WriteLine($"Total Change: $" + orderChange);
                PrintReceipt();

                Console.ReadKey();
                PrintReceipt();
            }
            PrintReceipt();
        }
        private double GetCash()
        {
            return double.Parse(Console.ReadLine());
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
                Console.Write("\nInvalid month.  \nEnter the Expiration Date(mm/yyyy): ");
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
            Console.WriteLine("Payment accepted.");
  
            PrintReceipt();
            Console.ReadKey();
        }
        public void PayCheck()
        {
            string checkNumber;
            double checkTotal;
            Console.Write("Enter the 4 digit check number: ");
            var checkVerify = new Regex(@"^\d{4}$");
            checkNumber = Console.ReadLine();
            PaymentGeneric = decimal.Parse(checkNumber);
            while (!checkVerify.IsMatch(checkNumber))
            {
                Console.Write("Invalid Entry. \nEnter the 4 digit check number: ");
                checkNumber = Console.ReadLine();
            }
            Console.Write("Enter Check Total: ");
            checkTotal = Convert.ToDouble(Console.ReadLine());
            while (checkTotal != TotalOrder)
            {
                Console.WriteLine("Totals do not match. Please verify total.");
                checkTotal = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Your check payment has cleared");
            
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
                switch (PaymentType) 
                {
                    case 1:
                        Console.WriteLine("Cash Payment");
                        break;
                    case 2:
                        Console.WriteLine("Credit/Debit Payment");
                        Console.WriteLine("XXXXXXXXXXXX{0}", PaymentGeneric.ToString().Substring(12)); 
                        break;
                    case 3:
                        Console.WriteLine("Check #{0}", PaymentGeneric);
                        break;
                    default:
                        break;
                }
            
            double change = CalculateChange(TotalOrder, (double)PaymentGeneric);
            Console.WriteLine("Subtotal: ${0:0.00}", SubTotal);
            Console.WriteLine("Tax: ${0:0.00}", CalculateTaxRate());
            Console.WriteLine("Total: ${0:0.00}", TotalOrder);
        }
    }
}