using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Cool_Coffee_Shop
{
    public class SeedDB
    {
        public List<Product> Run()
        {
            if (System.IO.File.Exists("seeddata.txt"))
            {
                Console.Write("Loading product list...");
                return LoadProducts();
            }
            else
            {
                Console.Write("Error: Product List file not found. No products loaded.\nPress any key to continue:");
                Console.ReadKey();
                return null;
            }
        }
        private List<Product> LoadProducts()
        {
            var productList = new List<Product>();
            using (var reader = new StreamReader("seeddata.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var lineArry = line.Split(',');
                    productList.Add(new Product(lineArry[0], lineArry[1], lineArry[2], double.Parse(lineArry[3])));
                }
            }
            Console.Write("Done\n\n");
            return productList;
        }
        public void AddNewProduct(Product newProduct)
        {
            using (var writer = new StreamWriter("seeddata.txt"))
            {
                //writer.WriteLine($"{newProduct.Name},{newProduct.Cateogory},{newProduct.Description},{newProduct.Price.ToString()}");
                //writer.Flush();
            }
        }
    }
}

// https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=netframework-4.8