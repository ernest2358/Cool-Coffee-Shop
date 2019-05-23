using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class CoffeeShopApp
    {
        public void Run()
        {
            var productList = CreateProductList();
            

            // Welcome message (Header block)
            Console.WriteLine("Super Cool Coffee Shop Program!");


            //Below, added some menu options and if statement (take in selection maybe chagne a bit*tryParse*)
            // Main menu - 1. create order, 2. exit, 3. Add new product. 4. Remove product from product list.
            var mainMenu = new MainMenu(productList) ;
            Console.WriteLine("Welcome to the Cool Coffee Shop, please press enter: ");
            Console.ReadKey();
            if (true)
            {
                mainMenu.RunMainMenu();
            }
            Console.WriteLine("Welcome to the main menu: ");
            //
            Console.WriteLine("Please make a selection between options 1-4");

            Console.WriteLine("1 - Create Order, 2 - Add a new product to menu, 3 - Remove a product from the menu 4 - Exit Coffee Shop App");
            var userSelection = int.Parse(Console.ReadLine());
            if (userSelection == 1)
            {
                CreateOrder(productList);
            }
            else if (userSelection == 2)
            {
                
            }
            //
            // probably a switch method to navigate to "Create Order" Menu
            CreateOrder(productList);
        }

        public void AddToAnOrder(Product addedProduct, int qty)
        {
            var OrderList = new List<OrderLine>();
            OrderList.Add(new OrderLine(addedProduct, qty));
        }

        public void CreateOrder(List<Product> productList)
        {
            var currentOrder = new Order();
            Console.WriteLine("Welcome to the Order Menu:");
            // Order menu - 1. add item to order, 2. checkout and pay, 3. Cancel order and return to main
            // Display options for submenus

            PrintMenu(productList);

            // Add item to order. Create method to ask user which product and what qty to add to order.
            currentOrder.AddToAnOrder(productList[0], 1);

            // When finished, total order and pay with:
            currentOrder.Pay();

            currentOrder.Cancel();
        }

        public List<Product> CreateProductList()
        {
            var seed = new SeedDB();
            return seed.Run();
        }

        public static void PrintMenu(List<Product> productList)
        {
            foreach (var product in productList)
            {
                if (true)//product.Category.Contains("Horror", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Product Name: {0}", product.Name);
                }
            }

        }
    }
}
