using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class MainMenu
    {
        public List<Product> ListOfProducts { get; set; }
        public HeaderBar Header { get; set; }

        public MainMenu(List<Product> productList)
        {
            ListOfProducts = productList;
            Header = new HeaderBar(64);
        }
        public void RunMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Header.DrawHeader();

                Console.WriteLine("Please make a selection between options 1-4");
                Console.WriteLine("1 - Create an Order, 2 - Add a new product to menu, 3 - Remove a product from the menu 4 - Exit Coffee Shop App");

                var userSelection = int.TryParse(Console.ReadLine(), out int result); // refactor this
                if (result == 1) // make this a switch
                {
                    CreateNewOrder();
                }
                else if (result == 2)
                {
                    var seed = new SeedDB();
                    seed.AddNewProduct();
                }
                else if (result == 3)
                {
                    //removeProduct from menu (SeedDB)() probs get rid of this
                }
                else if (result == 4)
                {
                    Console.WriteLine("Have a great day. Goodbye!!");
                    return;
                }
                else
                {
                    Console.WriteLine("The value you have entered is invalid. Please try again.");
                }
            }
        }
        private void CreateNewOrder()
        {
            var orderMenu = new OrderMenu(ListOfProducts);
            orderMenu.RunOrderMenu();
        }

    }

}
