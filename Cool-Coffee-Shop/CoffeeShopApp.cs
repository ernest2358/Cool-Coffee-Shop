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
            productList.Add(new Product("Cool Cup of Joe", "coffee", "The best cup of coffee in the land. Cocoa beans from Columbia topped off with 3 cups of cream and 3 sugar.", 4.99));
            productList.Add(new Product("Coffee Black", "coffee", "Our freshly brewed black coffee with cocoa beans from Columbia for our real coffee lovers.", 2.99));
            productList.Add(new Product("Cool Iced Coffe", "coffee", "Our flavorful iced coffee drink served to perfection. Cocoa beans from Columbia topped off with 3 cups of cream and 3 sugar,", 5.99));
            productList.Add(new Product("Caramel Frappuccino", "coffee", "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream and a delightful caramel drizzle to top it off.", 5.99));
            productList.Add(new Product("Double Chocolate Frappuccino", "coffee", "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream and a delightful chocolate drizzle to top it off.", 5.99));
            productList.Add(new Product("Vanilla Bean Frappuccino", "coffee", "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream to top it off.", 5.99));
            productList.Add(new Product("Peach Citrus White Tea", "tea", "Freshly brewed white iced tea with a sensation peach flavor taste.", 4.99));
            productList.Add(new Product("Cool Green Tea", "tea", "Freshly brewed green iced tea with an irresistable taste that will keep you coming back for more.", 4.99));
            productList.Add(new Product("Hot Chocolate", "hot chocolate", "Hot Chocolate”, A warm cup of hot chocolate, with a taste perfect for anytime of the day", 5.99));
            productList.Add(new Product("Bottle water", "water", "A refreshing bottle of Ice Mountain natural spring water", 1.99));
            productList.Add(new Product("Bagel", "food", "A plain toasted bagel with cream cheese", 1.99));
            productList.Add(new Product("Cool Cookie", "food", "A delicious chocolate chip cookie that will melt into your taste buds", 1.99));
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
