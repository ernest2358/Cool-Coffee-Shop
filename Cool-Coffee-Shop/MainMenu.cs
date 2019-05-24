using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class MainMenu
    {
        public List<Product> ListOfProducts { get; set; }

        public MainMenu(List<Product> productList)
        {
            ListOfProducts = productList;
        }
        public void RunMainMenu()
        {
            Console.Clear();

            //var runOrderMenu = new OrderMenu();
            //Above the compiler does not like this

            Console.WriteLine("Please make a selection between options 1-4");
            Console.WriteLine("1 - Create Order, 2 - Add a new product to menu, 3 - Remove a product from the menu 4 - Exit Coffee Shop App");
            var userSelection = int.Parse(Console.ReadLine());

            if (userSelection == 1)
            {
                CreateNewOrder();
            }
            else if (userSelection == 2)
            {
                //addNewProduct .  but does orderLine effect this??
            }
            else if (userSelection == 3)
            {
                //removeProduct
            }
            else
            {
                Console.WriteLine("Have a great day. Goodbye!!");
            }
        }
        private void CreateNewOrder()
        {
            var orderMenu = new OrderMenu(ListOfProducts);
            orderMenu.RunOrderMenu();
        }

    }

}
