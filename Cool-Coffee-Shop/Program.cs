using System;

namespace Cool_Coffee_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeShop = new CoffeeShopApp();

            var seed = new SeedDB();
            seed.AddNewProduct(new Product("Thing", "Things", "It's a thing!", 500));

            coffeeShop.Run();

            Console.WriteLine("\n\n===================================");
            Console.WriteLine("End of Demo. Press any key to exit.");
            Console.ReadKey();

        }
    }


}
