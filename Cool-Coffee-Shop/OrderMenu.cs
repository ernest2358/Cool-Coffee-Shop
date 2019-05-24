using System;
using System.Collections.Generic;

namespace Cool_Coffee_Shop
{
    public class OrderMenu
    {
        public List<Product> ListOfProducts { get; set; }

        public OrderMenu(List<Product>productList)
        {
            ListOfProducts = productList;
        }

        public void RunOrderMenu()
        {
            while (true)
            {
                Console.Clear();

                var newOrder = new Order();
                Console.WriteLine("Please make a selection between options 1-4");
                Console.WriteLine("1 - Add a new item to order, 2 - Remove a item from order, 3 - Checkout, 4 - Cancel order");
                var userSelection = int.Parse(Console.ReadLine());

                if (userSelection == 1)
                {   //Need to find a way to mkae this selection add to orderList in Order class (might have to change around Order class or create list here in this class)
                    var chosenProduct = ChooseProduct(); // create method for customer to choose a product from the product list
                    var quantity = ChooseQty(); // create method for customer to choose qty of product
                    newOrder.AddToAnOrder(chosenProduct, quantity);
                }
                else if (userSelection == 2)
                {
                    //addNewProductToOrder .  but does orderLine effect this??
                }
                else if (userSelection == 3)
                {
                    // process checkout
                    return;
                }
                else
                {
                    newOrder.Cancel();
                    return;
                }
            }
        }
        private Product ChooseProduct()
        {
            // user chooses a product from ListOfProducts
            Console.WriteLine("What would you like?");
            for (var i = 1; i <= ListOfProducts.Count; i++)
            {
                Console.WriteLine($"{i} - {ListOfProducts[i - 1].Name}");
            }
            Console.ReadKey();
            return ListOfProducts[0];
        }
        private int ChooseQty()
        {
            // user enters a positive integer
            return 2;
        }
    }
}
