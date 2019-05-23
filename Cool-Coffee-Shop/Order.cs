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
            double userPayCash,orderTotal, orderChange; // place holder
            userPayCash = 4 ;
            orderTotal = 0; //<- pull total from elsewhere and add here
            Console.WriteLine($"Cash Received: {userPayCash}");
            
            if (userPayCash > orderTotal)
            {
                orderChange = userPayCash - orderTotal;
                Console.WriteLine($"Total Change: " + orderChange);
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
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
            while (!int.TryParse(checkNumber, out checkVerify) && checkNumber.Length != 3)
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
            // return to main menu
        }
        public void PrintReceipt()
        {

        }
    }
}
