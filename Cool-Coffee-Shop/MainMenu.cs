﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class MainMenu
    {
        public List<Product> ListOfProducts { get; set; }
        public HeaderBar Header { get; set; }

        public MainMenu(List<Product> productList)
        {
            ListOfProducts = productList;
            Header = new HeaderBar(64);
        }
        public void RunMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Header.DrawHeader();
                Header.DrawMainMenuOptions();

                Console.Write("\nInput: ");

                var userSelection = Common.GetInt(1, 4);
                switch (userSelection)
                {
                    case 1:
                        CreateNewOrder();
                        break;
                    case 2:
                        AddNewProduct();
                        break;
                    case 3:
                        SeeTheMenu();
                        break;
                    case 4:
                        Console.WriteLine("Have a great day. Goodbye!!");
                        return;
                    default:
                        Console.WriteLine("The value you have entered is invalid. Please try again.");
                        break;
                }
            }
        }
        private void CreateNewOrder()
        {
            var orderMenu = new OrderMenu(ListOfProducts);
            orderMenu.RunOrderMenu();
        }
        private void SeeTheMenu()
        {
            Console.Clear();
            Header.DrawHeader();
            Header.DrawMenu(ListOfProducts);
            while (Common.KeepGoing("Would you like to learn more about a product?"))
            {
                LearnMore();
            }
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }
        private void LearnMore()
        {
            Console.Write($"Which product would you like to learn more about? (1-{ListOfProducts.Count})? ");
            var choice = Common.GetInt(1, ListOfProducts.Count);
            Console.Write($"\n{ListOfProducts[choice - 1].Name}: {ListOfProducts[choice - 1].Description}\n\n");
        }
        private void AddNewProduct()
        {
            var seed = new SeedDB();
            seed.AddNewProduct();
            ListOfProducts = seed.Run();
        }
    }

}