using System;
using System.Collections.Generic;

namespace Cool_Coffee_Shop
{
    public class OrderMenu
    {
        public List<Product> ListOfProducts { get; set; }
        public int SelectedItem { get; set; }
        public int NumberOfItemsSelected { get; set; }
        public HeaderBar Header { get; set; }
        public Order NewOrder { get; set; }
        //public int RemoveItem { get; set; }   this will be applied

        public OrderMenu(List<Product>productList)
        {
            ListOfProducts = productList;
            Header = new HeaderBar(64);
            NewOrder = new Order();
        }

        public void RunOrderMenu()
        {
            while (true)
            {
                Console.Clear();
                NewOrder.CalculateSubTotal();
                Header.DrawHeader(NewOrder);

                Console.WriteLine("Please make a selection between options 1-4");
                Console.WriteLine("1 - Add an item to order, 2 - Remove an item from order, 3 - Checkout, 4 - Cancel order");
                var userSelection = int.TryParse(Console.ReadLine(), out int result); 
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        Header.DrawHeader(NewOrder);
                        Header.DrawMenu(ListOfProducts);

                        var chosenProduct = ChooseProduct();
                        var quantity = ChooseQty();

                        NewOrder.AddToAnOrder(chosenProduct, quantity);
                        break;
                    case 2:
                        // var removeItemFromOrder = (creat prop removed item)
                        NewOrder.RemoveFromAnOrder();
                        break;
                    case 3:
                        NewOrder.Pay();
                        return;
                    default:
                        NewOrder.Cancel();
                        return;
                }
            }
        }
        private Product ChooseProduct()
        {
            SelectedItem = int.Parse(Console.ReadLine());
            return ListOfProducts[SelectedItem - 1];
        }
        private int ChooseQty()
        {
            Console.WriteLine($"Choose how many { ListOfProducts[SelectedItem - 1].Name } you would like?");
            //***Validate user input int, if they put anything other than positive int returns 1
            var howMany = int.TryParse(Console.ReadLine(), out int result);
            if (howMany == false)
            {
                result = 1;
            }
            return result;
        }
    }
}