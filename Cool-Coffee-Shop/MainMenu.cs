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

                var userSelection = int.TryParse(Console.ReadLine(), out int result); 
                switch (result)
                {
                    case 1:
                        CreateNewOrder();
                        break;
                    case 2:
                        var seed = new SeedDB();
                        seed.AddNewProduct();
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("Have a great day. Goodbye!!");
                        return;
                    default:
                        Console.WriteLine("The value you have entered is invalid. Please try again.");
                        break;
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
