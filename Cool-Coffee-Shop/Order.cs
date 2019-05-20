using System;
using System.Collections.Generic;

namespace Cool_Coffee_Shop
{
    public class Order : Product
    {
        public Order()
        {
            //Should we create a list of categories (list of [Lists of products]???) Or the opposite way around?
            var category = new List<string>();
            category.Add("coffee");
            //Should list of products be displayed here?  Or only list selectedProducts in listOfPro
            foreach (var product in listOfProducts)
            {
                Console.WriteLine(product);
            }
                //Or a bunch of conditionals can be met if a user choses which ever product
            CoolIcedJoe();
        }
        //Functions to invoke an order    OR should these be interfaces?
        public Product AddToAnOrder()
        {

        }

        public Product RemoveFromAnOrder()
        {

        }
    }
}
