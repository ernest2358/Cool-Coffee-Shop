using System;
using System.Collections.Generic;

namespace Cool_Coffee_Shop
{
    public class Product
    {
        public string Name { get; set; }
        public string Cateogory { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string name, string cateogory, string desc, double price)
        {
            Name = name;
            Cateogory = Cateogory;
            Description = desc;
            Price = price;
        }




        //public Product Drinks()
        //{
        //    var coolCupOfJoe = new Product();
        //    coolCupOfJoe.Cateogory = "coffee";
        //    coolCupOfJoe.Name = "Cool Cup of Joe";
        //    coolCupOfJoe.Price = 4.99;
        //    coolCupOfJoe.Description = "The best cup of coffee in the land. Cocoa beans from Columbia topped off with 3 cups of cream and 3 sugar.";
        //    listOfProducts.Add(coolCupOfJoe);
        //    return coolCupOfJoe;
        //}

        //public Product CoolIcedJoe()
        //{
        //    var coolIcedJoe = new Product();
        //    coolIcedJoe.Cateogory = "coffee";
        //    coolIcedJoe.Name = "Cool Iced Joe";
        //    coolIcedJoe.Price = 5.99;
        //    coolIcedJoe.Description = "Our flavorful iced coffee drink served to perfection. Cocoa beans from Columbia topped off with 3 cups of cream and 3 sugar.";
        //    listOfProducts.Add(coolIcedJoe);
        //    return coolIcedJoe;
        //}

        //public Product CoffeeBlack()
        //{
        //    var coffeeBlack = new Product();
        //    coffeeBlack.Cateogory = "coffee";
        //    coffeeBlack.Name = "Cofffee Black";
        //    coffeeBlack.Price = 2.99;
        //    coffeeBlack.Description = "Our freshly brewed black coffee with cocoa beans from Columbia for our real coffee lovers.";
        //    listOfProducts.Add(coffeeBlack);
        //    return coffeeBlack;
        //}

        //public Product CaramelFrappuccino()
        //{
        //    var caramelFrappuccino = new Product();
        //    caramelFrappuccino.Cateogory = "coffee";
        //    caramelFrappuccino.Name = "Caramel Frappuccino";
        //    caramelFrappuccino.Price = 5.99;
        //    caramelFrappuccino.Description = "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream and a delightful caramel drizzle to top it off.";
        //    listOfProducts.Add(caramelFrappuccino);
        //    return caramelFrappuccino;
        //}

        //public Product DoubleChocolateFrappuccino()
        //{
        //    var caramelFrappuccino = new Product();
        //    caramelFrappuccino.Cateogory = "coffee";
        //    caramelFrappuccino.Name = "Double Chocolate Frappuccino";
        //    caramelFrappuccino.Price = 5.99;
        //    caramelFrappuccino.Description = "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream and a delightful chocolate drizzle to top it off.";
        //    listOfProducts.Add(caramelFrappuccino);
        //    return caramelFrappuccino;
        //}

        //public Product VanillaBeanFrappuccino()
        //{
        //    var vanillaBean = new Product();
        //    vanillaBean.Cateogory = "coffee";
        //    vanillaBean.Name = "Vanilla Bean Frappuccino";
        //    vanillaBean.Price = 5.99;
        //    vanillaBean.Description = "Delicious frappuccino made with cocoa beans from Columbia, with whipped cream to top it off.";
        //    listOfProducts.Add(vanillaBean);
        //    return vanillaBean;
        //}

        //public Product CoolGreenTea()
        //{
        //    var coolGreenTea = new Product();
        //    coolGreenTea.Cateogory = "tea";
        //    coolGreenTea.Name = "Cool Geen Tea";
        //    coolGreenTea.Price = 4.99;
        //    coolGreenTea.Description = "Freshly brewed green iced tea with an irresistable taste that will keep you coming back for more.";
        //    listOfProducts.Add(coolGreenTea);
        //    return coolGreenTea;
        //}

        //public Product PeachCitrusWhiteTea()
        //{
        //    var peachCitrusWhiteTea = new Product();
        //    peachCitrusWhiteTea.Cateogory = "tea";
        //    peachCitrusWhiteTea.Name = "Peach Citrus White Tea";
        //    peachCitrusWhiteTea.Price = 4.99;
        //    peachCitrusWhiteTea.Description = "Freshly brewed white iced tea with a sensation peach flavor taste.";
        //    listOfProducts.Add(peachCitrusWhiteTea);
        //    return peachCitrusWhiteTea;
        //}

        //public Product HotChocolate()
        //{
        //    var hotChocolate = new Product();
        //    hotChocolate.Cateogory = "Hot Chocolate";
        //    hotChocolate.Name = "Hot Chocolate";
        //    hotChocolate.Price = 5.99;
        //    hotChocolate.Description = "A warm cup of hot chocolate, with a taste perfect for anytime of the day";
        //    listOfProducts.Add(hotChocolate);
        //    return hotChocolate;
        //}

        //public Product BottledWater()
        //{
        //    var bottledWater = new Product();
        //    bottledWater.Cateogory = "water";
        //    bottledWater.Name = "Bottled Water";
        //    bottledWater.Price = 1.99;
        //    bottledWater.Description = "A refreshing bottle of Ice Mountain natural spring water";
        //    listOfProducts.Add(bottledWater);
        //    return bottledWater;
        //}

        //public Product Bagel()
        //{
        //    var bagel = new Product();
        //    bagel.Cateogory = "food";
        //    bagel.Name = "bagel";
        //    bagel.Price = 1.99;
        //    bagel.Description = "A plain toasted bagel with cream cheese";
        //    listOfProducts.Add(bagel);
        //    return bagel;
        //}

        //public Product CoolCookie()
        //{
        //    var coolCookie = new Product();
        //    coolCookie.Cateogory = "food";
        //    coolCookie.Name = "Cool Cookie";
        //    coolCookie.Price = 1.99;
        //    coolCookie.Description = "A delicious chocolate chip cookie that will melt into your taste buds";
        //    listOfProducts.Add(coolCookie);
        //    return coolCookie;
        //}
    }
}
