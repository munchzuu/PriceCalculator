using ShoppingCart.PriceCalculator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.PriceCalculator
{
    interface IDiscountCalculator
    {
        IEnumerable<DiscountMessage> CalculateDiscount(IEnumerable<Product> products);
    }
}
