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


            // Main menu - 1. create order, 2. exit, 3. Add new product. 4. Remove product from product list.

            Console.WriteLine("Welcome to the main menu: ");
            Console.WriteLine("1 - Create Order, 2 - Exit Coffee Shop App");
            // probably a switch method to navigate to "Create Order" Menu

            CreateOrder(productList);

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
            var productList = new List<Product>();
            productList.Add(new Product("Coffee, Black", "Drink", "It's a cup of coffee", 500));
            productList.Add(new Product("Hot Dog", "Food?", "Food-like food", 3));

            return productList;
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
