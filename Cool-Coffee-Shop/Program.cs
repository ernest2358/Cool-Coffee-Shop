using System;

namespace Cool_Coffee_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeShop = new CoffeeShopApp();
            coffeeShop.Run();

            Console.WriteLine("\n\n===================================");
            Console.WriteLine("End of Demo. Press any key to exit.");
            Console.ReadKey();
        }
    }


}