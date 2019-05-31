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
        public double PaymentGeneric { get; set; } //cash payment
        public int PaymentType { get; set; } // credit, check
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
                //Right now Remove from order does nothing
                //Attempted to print the current order and have the user select what they would like to remove but items in orderlist are not appearring. for and foreach loop
                //Should it be a perimeter of type Product to remove the specific Product Item   
        public void RemoveFromAnOrder() // ??
        {
            for (var i = 1; i <= OrderList.Count; i++)
            {
                Console.WriteLine($"{ i} - { OrderList[i - 1].Item}");
            }
        }
        //Get rid of above possibly and change Order Menu
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
             
            // Console.WriteLine($"Your grand total is: {TotalOrder}");
            while (true)
            {
                Console.WriteLine($"How would you like to pay for your order? Please select options 1-3: \n1 - Cash, 2 - Crdeit/Debit, 3 - Check");
                //*** Maybe no need for Enum Payment Type, just ask for an int and switch  should follow?***

                var paymentType = int.TryParse(Console.ReadLine(), out int result);
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
            double userPayCash, orderChange; // place holder
            Console.Write("How much cash do you offer? ");
            userPayCash = GetCash(); // get input from user, cash paid.
            Console.WriteLine($"Cash Received: ${userPayCash}");
            while (userPayCash < TotalOrder)
            {
                /*Console.Write("How much cash do you offer? ");
                userPayCash = GetCash(); // get input from user, cash paid.
                Console.WriteLine($"Cash Received: ${userPayCash}");

                if (userPayCash >= TotalOrder)
                {
                    orderChange = userPayCash - TotalOrder;
                    Console.WriteLine($"Total Change: $" + orderChange);
                    Console.ReadKey();
                    return;
                }*/
                //else

                    Console.WriteLine("Insufficient funds.");
                    userPayCash = GetCash(); // get input from user, cash paid.

                    Console.ReadKey();

            }
            if (userPayCash >= TotalOrder)
            {
                orderChange = userPayCash - TotalOrder;
                Console.WriteLine($"Total Change: $" + orderChange);
                PrintReceipt();

                Console.ReadKey();
                PrintReceipt();

                //return;
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

            Console.Write("Enter the 16 Digit Card Number:: ");
            var cardCheck = new Regex(@"^([\-\s]?[0-9]{4}){4}$");
            userCCNumber = Console.ReadLine();
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
            Console.ReadKey();
            PrintReceipt();
        }
        public void PayCheck()
        {
            string checkNumber;
            double checkTotal;
            Console.Write("Enter the 4 digit check number: ");
            var checkVerify = new Regex(@"^\d{4}$");
            checkNumber = Console.ReadLine();
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
            Console.ReadKey();
            PrintReceipt();
        }
        public void Cancel()
        {
            Console.WriteLine($"Order {OrderID} has been cancelled. Press any key to return to main menu.");
            Console.ReadKey();
        }

        public void PrintReceipt()//List<OrderLine> OrderList, double payment)
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
                switch (PaymentType) //make sure switch statement is displayed properly
                {
                    case 0:
                        Console.WriteLine("Cash Payment");
                        break;
                    case 1:
                        var lastFourDigits = Console.Read();
                        Console.WriteLine("Credit/Debit Payment");
                        Console.WriteLine("XXXXX{0}", lastFourDigits); //make this better
                        break;
                    case 2:
                        Console.WriteLine("Check Payment");
                        break;
                    default:
                        break;
                }
            }
            double change = CalculateChange(TotalOrder, PaymentGeneric);
            Console.WriteLine("Subtotal: ${0:0.00}", SubTotal);
            Console.WriteLine("Tax: ${0:0.00}", CalculateTaxRate());
            Console.WriteLine("Total: ${0:0.00}", TotalOrder);
            //Console.WriteLine("Payment: ${0:0.00}", PaymentGeneric);//should show payment received
            //Console.WriteLine("Your change is ${0: 0.00}", change);//should show exact change
            //make sure this runs properly
        }
    }
}
