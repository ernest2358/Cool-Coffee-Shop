using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class CoffeeShopApp
    {
        public void Run()
        {
            var header = new HeaderBar(64);
            header.DrawHeader();

            var productList = CreateProductList();
            if (productList == null) return;

            Console.WriteLine("Please press any key to continue to the Main Menu:");
            Console.ReadKey();

            var mainMenu = new MainMenu(productList);
            mainMenu.RunMainMenu();
        }
        public List<Product> CreateProductList()
        {
            var seed = new SeedDB();
            return seed.Run();
        }
    }
}