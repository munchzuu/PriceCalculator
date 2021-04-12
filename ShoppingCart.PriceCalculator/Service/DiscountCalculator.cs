using ShoppingCart.PriceCalculator.Model;
using System.Collections.Generic;

namespace ShoppingCart.PriceCalculator
{
    class DiscountCalculator
    {
        private IDiscountCalculator _discountCalculator;

        public DiscountCalculator(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public void SetCalculator(IDiscountCalculator discountCalculator) => _discountCalculator = discountCalculator;

        public IEnumerable<DiscountMessage> Calculate(IEnumerable<Product> products) => _discountCalculator.CalculateDiscount(products);
    }
}
