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
            var header = new HeaderBar(64);
            header.DrawHeader();
            Console.WriteLine($"Please press enter to continue to the Main Menu:");

            Console.ReadKey();

            var mainMenu = new MainMenu(productList) ;
            mainMenu.RunMainMenu();
        }
        public List<Product> CreateProductList()
        {
            var seed = new SeedDB();
            return seed.Run();
        }
    }
}
