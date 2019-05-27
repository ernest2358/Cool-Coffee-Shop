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
            Console.WriteLine("1 - Create an Order, 2 - Add a new product to menu, 3 - Remove a product from the menu 4 - Exit Coffee Shop App");
            var userSelection = int.TryParse(Console.ReadLine(), out int result);             if (result == 1)
            {
                CreateNewOrder();
            }
            //****Possibly remove 2 and 3 options???
            else if (result == 2)
            {
                //addNewProduct to the menu(SeedDB) (brand new product on the menu, ask for: string name, string category, string description, int price)
            }
            else if (result == 3)
            {
                //removeProduct from menu (SeedDB)()
            }
            else if (result == 4)
            {
                Console.WriteLine("Have a great day. Goodbye!!");
            }
            else
            {
                Console.WriteLine("The value you have entered is invalid. Please try again.");
            }
        }
        private void CreateNewOrder()
        {
            var orderMenu = new OrderMenu(ListOfProducts);
            orderMenu.RunOrderMenu();
        }

    }

}
