using ShoppingCart.PriceCalculator.Model;
using System.Collections.Generic;

namespace ShoppingCart.PriceCalculator
{
    public class NoDiscountCalculator : IDiscountCalculator
    {
        public IEnumerable<DiscountMessage> CalculateDiscount(IEnumerable<Product> products)
        {
            List<DiscountMessage> msgs = new List<DiscountMessage>();
            return msgs;
        }
    }
}
