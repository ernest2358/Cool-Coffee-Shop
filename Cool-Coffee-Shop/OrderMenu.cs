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

        public OrderMenu(List<Product> productList)
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
                Header.DrawOrderMenuOptions();
                var userSelection = Common.GetInt(1, 5); 
                switch (userSelection)
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
                        Console.Clear();
                        Header.DrawHeader(NewOrder);
                        Header.DrawCart(NewOrder);
                        NewOrder.RemoveFromAnOrder();
                        break;
                    case 3:
                        NewOrder.Pay();
                        return;
                    case 4:
                        NewOrder.Cancel();
                        return;
                    case 5:
                        SeeCart();
                        break;
                    default:
                        NewOrder.Cancel();
                        return;
                }
            }
        }
        private Product ChooseProduct()
        {
            SelectedItem = Common.GetInt(1, ListOfProducts.Count);
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
        private void SeeCart()
        {
            Console.Clear();
            Header.DrawHeader(NewOrder);
            Header.DrawCart(NewOrder);
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }
    }
}