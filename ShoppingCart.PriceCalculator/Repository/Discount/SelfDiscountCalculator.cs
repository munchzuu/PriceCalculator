using ShoppingCart.PriceCalculator.Model;
using ShoppingCart.PriceCalculator.Util;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.PriceCalculator
{
    /// <summary>
    /// This class calculates the discount based on the rules
    /// </summary>
    public class SelfDiscountCalculator : IDiscountCalculator
    {
        private const decimal discountPercentage = 0.10m;

        /// <summary>
        /// Calculates the discount of products in the basket
        /// </summary>
        /// <param name="products">List of products added in the basket</param>
        /// <returns>return screen display message</returns>
        public IEnumerable<DiscountMessage> CalculateDiscount(IEnumerable<Product> products)
        {
            List<DiscountMessage> msgs = new List<DiscountMessage>();

            var selfDiscountProducts = from product in products
                       where product.DiscountType == ProductDiscountType.SelfPrdPriceDiscount
                       group product by product.ProductName into p
                       select p;


            foreach(var pd in selfDiscountProducts)
            {                
                var reducedAmount = UnitCalculator.ApplyDiscount(pd.Count(), pd.FirstOrDefault().UnitPrice, discountPercentage);
                msgs.Add
                    (new DiscountMessage
                    {
                        DiscountAmount = reducedAmount,
                        Message = $"{pd.Key} {(0.10m * 100).ToString("0.##")}% off : -{CurrencyFormater.ToCurrencyString(reducedAmount)}"
                    });
            }
            return msgs;
        }
    }
}
