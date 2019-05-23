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
        //public Product RemoveFromAnOrder() { }
        public void CalculateTotal(List<OrderLine> OrderList)
        {
            TotalOrder = CalculateSubTotal(OrderList) + CalculateTaxRate(OrderList);
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
                var input = PaymentType.Credit;
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
        public void PayCash()
        { 
            double userPayCash, orderChange; // place holder
            while (true)
            {
                userPayCash = GetCash(); // get input from user, cash paid.
                Console.WriteLine($"Cash Received: {userPayCash}");

                if (userPayCash > TotalOrder)
                {
                    orderChange = userPayCash - TotalOrder;
                    Console.WriteLine($"Total Change: " + orderChange);
                    return;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
        }
        private double GetCash()
        {
            // get cash from user.
            return 5.00;
        }
        public void PayCredit() //need to validate number, date, cvv 
        {
            string userCCNumber, userCCExpireDate, userCVV;

            Console.Write("Enter Credit Card Number: ");
            userCCNumber = Console.ReadLine();
            int cCnumber = 0;
            while (!int.TryParse(userCCNumber, out cCnumber) && userCCNumber.Length == 15) 
            {
                Console.Write("\nInvalid card number. \nEnter the 16 digit card number located on the front:");
                userCCNumber = Console.ReadLine();
            }

            Console.Write("\nEnter Credit Card Experation Date: ");//<- still need to validate the date
            userCCExpireDate = Console.ReadLine();
            int cCExpireDate = 0;
           
            while (!int.TryParse(userCCExpireDate, out cCExpireDate))  
            {
                Console.Write("\nInvalid Experation Date.  \nEnter  Experation Date: ");
                userCCExpireDate = Console.ReadLine();
            }

            Console.Write("\nEnter Credit Card CVV: ");
            userCVV = Console.ReadLine();
            int cVV = 0;
            while (!int.TryParse(userCVV, out cVV) && userCVV.Length == 2)  //Also need to check for 3 digit intiger
            {
                Console.Write("\nInvalid CVV.  \nEnter 3 Digit CVV located on the back of the card: ");
                userCVV = Console.ReadLine();
            }

            double userCredit, orderTotal;
            userCredit = Convert.ToDouble(Console.ReadLine());
            orderTotal =0;  //<- pull total from elsewhere and add here 
            while(userCredit != orderTotal)
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
