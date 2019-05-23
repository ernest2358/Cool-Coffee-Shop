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
            var productList = new List<Product>();
            productList.Add(new Product("#1 Cool Cup of Joe", "coffee", "The best cup of coffee in the land. Cocoa beans from Columbia topped off with 3 cups of cream and 3 sugar.", 4.99));
            productList.Add(new Product("#2 Coffee Black", "coffee", "Our freshly brewed black coffee with cocoa beans from Columbia for our real coffee lovers.", 2.99));
            productList.Add(new Product("#3 Cool Iced Coffee", "coffee", "Our flavorful iced coffee drink served to perfection. Cocoa beans from Columbia topped off with 3 cups of cream and 3 sugar,", 5.99));
            productList.Add(new Product("#4 Caramel Frappuccino", "coffee", "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream and a delightful caramel drizzle to top it off.", 5.99));
            productList.Add(new Product("#5 Double Chocolate Frappuccino", "coffee", "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream and a delightful chocolate drizzle to top it off.", 5.99));
            productList.Add(new Product("#6 Vanilla Bean Frappuccino", "coffee", "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream to top it off.", 5.99));
            productList.Add(new Product("#7 Peach Citrus White Tea", "tea", "Freshly brewed white iced tea with a sensation peach flavor taste.", 4.99));
            productList.Add(new Product("#8 Cool Green Tea", "tea", "Freshly brewed green iced tea with an irresistible taste that will keep you coming back for more.", 4.99));
            productList.Add(new Product("#9 Hot Chocolate", "hot chocolate", "Hot Chocolate”, A warm cup of hot chocolate, with a taste perfect for anytime of the day", 5.99));
            productList.Add(new Product("#10 Bottle Water", "water", "A refreshing bottle of Ice Mountain natural spring water", 1.99));
            productList.Add(new Product("#11 Bagel", "food", "A plain toasted bagel with cream cheese", 1.99));
            productList.Add(new Product("#12 Cool Cookie", "food", "A delicious chocolate chip cookie that will melt into your taste buds", 1.99));
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
