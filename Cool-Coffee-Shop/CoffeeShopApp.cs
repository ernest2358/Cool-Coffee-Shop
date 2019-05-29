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
            if (productList == null) return;

            // Welcome message (Header block)
            Console.WriteLine($"Super Cool Coffee Shop Program!\nPlease press enter to continue to the Main Menu:");
            var header = new HeaderBar(64);
            header.DrawHeader();
            Console.ReadKey();
            var mainMenu = new MainMenu(productList) ;
            mainMenu.RunMainMenu();
        }

        public void AddToAnOrder(Product addedProduct, int qty)
        {
            var OrderList = new List<OrderLine>();
            OrderList.Add(new OrderLine(addedProduct, qty));
        }

        //**I believe this is redundant, covered through menu classes.... Have not deleted yet wait until up to date 
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
        //***Until this point ****** create product List 

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
