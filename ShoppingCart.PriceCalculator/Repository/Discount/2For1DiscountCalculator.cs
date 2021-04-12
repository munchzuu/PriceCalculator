using ShoppingCart.PriceCalculator.Model;
using System.Collections.Generic;

namespace ShoppingCart.PriceCalculator.Repository.Discount
{
    class _2For1DiscountCalculator : IDiscountCalculator
    {
        public IEnumerable<DiscountMessage> CalculateDiscount(IEnumerable<Product> products)
        {
            List<DiscountMessage> msgs = new List<DiscountMessage>();
            return msgs;
        }
    }
}
