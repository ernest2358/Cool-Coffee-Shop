using System;
using System.Collections.Generic;

namespace Cool_Coffee_Shop {     public class OrderMenu     {         public List<Product> ListOfProducts { get; set; }         public int SelectedItem { get; set; }         public int NumberOfItemsSelected { get; set; }
        public List<Product> Cart { get; set; }
        //public int RemoveItem { get; set; }   this will be applied          public OrderMenu(List<Product>productList)         {             ListOfProducts = productList;         }          public void RunOrderMenu()         {             while (true)             {                 Console.Clear();                  var newOrder = new Order();                  Console.WriteLine("Please make a selection between options 1-4");                 Console.WriteLine("1 - Add an item to order, 2 - Remove an item from order, 3 - Checkout, 4 - Cancel order");                 var userSelection = int.TryParse(Console.ReadLine(), out int result);                  if (result == 1)                 {   //Need to find a way to mkae this selection add to orderList in Order class (might have to change around Order class or create list here in this class)                     var chosenProduct = ChooseProduct(); // create method for customer to choose a product from the product list                     var quantity = ChooseQty(); // create method for customer to choose qty of product                     //***find a way to list selections?
                    newOrder.AddToAnOrder(chosenProduct, quantity);
                 }                 else if (result == 2)                 {   //Attempted to remove item and in Order class attempted to make function
                    // var removeItemFromOrder = (creat prop removed item)
                    newOrder.RemoveFromAnOrder();                 }                 else if (result == 3)                 {                     newOrder.Pay();                     return;                 }                 else                 {                     newOrder.Cancel();                     return;                 }             }         }         private Product ChooseProduct()         {             // user chooses a product from ListOfProducts             Console.WriteLine("What would you like?");             for (var i = 1; i <= ListOfProducts.Count; i++)             {                 Console.WriteLine($"{ i} - { ListOfProducts[i - 1].Name}");             }
            //****Handling exception is not working with if statement, maybe try/catch which works but throws in an error with some correct selections

            SelectedItem = int.Parse(Console.ReadLine());
            //var choice = int.TryParse(Console.ReadLine(), out int item);
            //item = SelectedItem;
            //if (item > ListOfProducts.Count)
            //{
            //    Console.WriteLine("Please selecet a valid choice from the given menu.");
            //    return null;
            //}
            //****selected item may be coming back as 1 rather than actual Product Cool Cup of Joe?

            return ListOfProducts[SelectedItem - 1];         }         private int ChooseQty()         {             Console.WriteLine($"Choose how many { ListOfProducts[SelectedItem - 1].Name } you would like?");             //***Validate user input int, if they put anything other than positive int returns 1             var howMany = int.TryParse(Console.ReadLine(), out int result);
            if (howMany == false)
            {
                result = 1;
            }             return result;         }
        /**Adding to OrderList what the user wants...might not need
        private void OrderListForCheckout(Product choice, int qty)
        {
            //var itemAdded;
            Cart.Add(choice);
        }
        */
    } }