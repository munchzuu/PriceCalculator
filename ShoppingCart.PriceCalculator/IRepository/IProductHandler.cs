using ShoppingCart.PriceCalculator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.PriceCalculator
{
    /// <summary>
    /// Interface to connect the Product handler and main program
    /// </summary>
    internal interface IProductHandler
    {        
        IEnumerable<Product> AddProductsToBasket(IEnumerable<string> products);

        Decimal SubTotal(IEnumerable<Product> products);
    }
}
