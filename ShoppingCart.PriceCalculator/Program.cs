using ShoppingCart.PriceCalculator.Model;
using ShoppingCart.PriceCalculator.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace ShoppingCart.PriceCalculator
{
    class Program
    {
        //NLog logger initializer
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Starting of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length == 0)
                {
                    Console.WriteLine("There are no items in the basket to calculate the price. Please enter the items...");
                }
                else
                {
                    var products = new ProductService().AddProductsToBasket(args);
                    if (products.Count() == 0)
                    {
                        Console.WriteLine("ERROR : Given items are not available.");
                        logger.Error("Given items are not available.");
                    }
                    else if (products.Count() != args.Length)
                    {
                        //if required, we can loop through and display the missing items.
                        Console.WriteLine("WARN : Some Items are not added into the Cart.");
                        logger.Warn("Some Items are not added into the Cart.");
                    }

                    if (products.Count() > 0)
                    {
                        var calculatorContext = new DiscountCalculator(new SelfDiscountCalculator());
                        List<DiscountMessage> discountMsg = calculatorContext.Calculate(products).ToList();

                        calculatorContext.SetCalculator(new HalfPriceDiscountCalculator());
                        discountMsg.AddRange(calculatorContext.Calculate(products));

                        calculatorContext.SetCalculator(new NoDiscountCalculator());
                        discountMsg.AddRange(calculatorContext.Calculate(products));


                        var subTotal = new ProductService().SubTotal(products);
                        Console.WriteLine("SubTotal : " + $"{CurrencyFormater.ToCurrencyString(subTotal)}");



                        if (discountMsg.Count() > 0)
                        {
                            discountMsg.ForEach(msg => Console.WriteLine(msg.Message));
                        }
                        else
                        {
                            Console.WriteLine("(No offers available)");
                        }
                        var totalprice = subTotal - discountMsg.Sum(s => s.DiscountAmount);

                        Console.WriteLine("Total Price: " + $"{CurrencyFormater.ToCurrencyString(totalprice)}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : An error occured during the price calculation : " + ex.ToString());
                logger.Error(ex.ToString());
            }
        }
    }
}
