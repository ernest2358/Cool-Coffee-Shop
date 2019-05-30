using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Cool_Coffee_Shop
{
    public class SeedDB
    {
        // public string OutputDirectory { get; set; }
        public string DataFile { get; set; }

        public SeedDB()
        {
            // OutputDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            DataFile = "../../../../seeddata.txt";
        }
        public List<Product> Run()
        {
            if (System.IO.File.Exists(DataFile))
            {
                Console.Write("Loading product list...");
                return LoadProducts();
            }
            else
            {
                Console.WriteLine("Error: Product List file not found. No products loaded...");
                Console.ReadKey();
                return null;
            }
        }
        private List<Product> LoadProducts()
        {
            var productList = new List<Product>();
            using (var reader = new StreamReader(DataFile))
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
        public void AddNewProduct()
        {
            Console.WriteLine("Adding new product"); // refactor this too.
            Console.Write("What is the new product name: ");
            var name = Console.ReadLine();
            Console.Write("What is the new product category: ");
            var category = Console.ReadLine();
            Console.Write("What is the new product description: ");
            var desc = Console.ReadLine();
            Console.Write("What is the new product price: ");
            var price = double.Parse(Console.ReadLine());

            var newProduct = new Product(name, category, desc, price);

            var product = new String($"\n{newProduct.Name},{newProduct.Cateogory},{newProduct.Description},{newProduct.Price.ToString()}");
            File.AppendAllText(DataFile, product);
        }
    }
}