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
        public double CalculateTaxRate()
        {
            return SubTotal * TaxRate;
        }
        public void Pay()
        {
            CalculateTotal();

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
            while (true)
            {
                Console.Write("How much cash do you offer? ");
                userPayCash = GetCash(); // get input from user, cash paid.
                Console.WriteLine($"Cash Received: ${userPayCash}");

                if (userPayCash > TotalOrder)
                {
                    orderChange = userPayCash - TotalOrder;
                    Console.WriteLine($"Total Change: $" + orderChange);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                    Console.ReadKey();
                }
            }
        }
        private double GetCash()
        {
            return double.Parse(Console.ReadLine());
        }
        public void PayCredit() //need to validate number, date, cvv
        {
            string userCCNumber, userCVV, userCCMonth, userCCYear;

            Console.Write("Enter Credit Card Number: ");
            userCCNumber = Console.ReadLine();
            while (!int.TryParse(userCCNumber, out int cCnumber) && userCCNumber.Length != 16)
            {
                Console.Write("\nInvalid card number. \nEnter the 16 digit card number located on the front:");
                userCCNumber = Console.ReadLine();
            }
            Console.Write("\nEnter Credit Card Expiration Date");//<- still need to validate the date
            Console.Write("\nEnter the month(mm): ");
            userCCMonth = Console.ReadLine();
            int cCMonth = 0;
            while (!int.TryParse(userCCMonth, out cCMonth) && cCMonth > 0 && cCMonth < 13)
            {
                Console.Write("\nInvalid month.  \nEnter the month(mm): ");
                userCCMonth = Console.ReadLine();
            }
            Console.Write("\nEnter Year (yyyy): ");
            userCCYear = Console.ReadLine();

            while (!int.TryParse(userCCYear, out int cCYear) && cCYear > 2000)
            {
                Console.Write("\nInvalid year.  \nEnter Year (yyyy): ");
                userCCYear = Console.ReadLine();
            }
            Console.Write("\nEnter Credit Card CVV: ");
            userCVV = Console.ReadLine();
            int cVV = 0;
            while (!int.TryParse(userCVV, out cVV) && userCVV.Length == 2)  //Also need to check for 3 digit intiger
            {
                Console.Write("\nInvalid CVV.  \nEnter 3 Digit CVV located on the back of the card: ");
                userCVV = Console.ReadLine();
            }

            double userCredit;
            userCredit = Convert.ToDouble(Console.ReadLine());
            while (userCredit != TotalOrder)
            {
                Console.WriteLine("Insufficiant funds. Please verify total.");
                userCredit = Convert.ToDouble(Console.ReadLine());
            }
        }
        public void PayCheck()
        {
            int checkVerify;
            string checkNumber;
            double checkTotal, orderTotal;
            Console.Write("Please enter the four(4) digit check number: ");
            checkNumber = Console.ReadLine();
            while (!int.TryParse(checkNumber, out checkVerify) && checkNumber.Length == 3)
            {
                Console.WriteLine("Invalid Entry. Please re-enter the check number: ");
                checkNumber = Console.ReadLine();
            }

            checkTotal = Convert.ToDouble(Console.ReadLine()); //<- Place holder
            orderTotal = 0; //<- Place holder Pull total from elsewhere. 
            while(checkTotal != orderTotal)
            {
                Console.WriteLine("Insufficiant funds. Please verify total.");
                checkTotal = Convert.ToDouble(Console.ReadLine());
            }
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
