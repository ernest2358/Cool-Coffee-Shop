using System;
using System.Collections.Generic;

namespace Cool_Coffee_Shop
{
    public class OrderMenu
    {
        public List<Product> userOrder { get; set; }

        public OrderMenu(List<Product>productList)
        {
            userOrder = productList;
        }

        public void RunOrderMenu()
        {
            var makeAnOrder = new CoffeeShopApp();
            var changeOrderList = new Order();
            Console.WriteLine("Please make a selection between options 1-4");
            Console.WriteLine("1 - Add a new item to order, 2 - Remove a item from order, 3 - Checkout, 4 - Cancel order");
            var userSelection = int.Parse(Console.ReadLine());

            if (userSelection == 1)
            {   //Need to find a way to mkae this selection add to orderList in Order class (might have to change around Order class or create list here in this class)
                makeAnOrder.CreateOrder(userOrder);
            }
            else if (userSelection == 2)
            {
                //addNewProductToOrder .  but does orderLine effect this??
            }
            else if (userSelection == 3)
            {
                //removeProductFromOrder
            }
            else
            {
                //Cancel order
            }
        }
    }
}
