using ShoppingCart.PriceCalculator.Model;
using ShoppingCart.PriceCalculator.Util;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.PriceCalculator
{
    public class HalfPriceDiscountCalculator : IDiscountCalculator
    {
        private readonly List<ProductDiscount> _discountItems;

        /// <summary>
        /// This contructor sets the constant discounts, we can modify this to add items using a method
        /// </summary>
        public HalfPriceDiscountCalculator()
        {
            _discountItems = new List<ProductDiscount>
            {                
                new ProductDiscount{EligibleProductName = "Beans", DiscountedProductName="Bread", DiscountPercentage=.50m}
            };
        }

        /// <summary>
        /// Calculates the discount of products in the basket
        /// </summary>
        /// <param name="products">List of products added in the basket</param>
        /// <returns>return screen display message</returns>        
        public IEnumerable<DiscountMessage> CalculateDiscount(IEnumerable<Product> products)
        {
            List<DiscountMessage> msgs = new List<DiscountMessage>();
            var diffDiscountProducts = from product in products
                                       where product.DiscountType == ProductDiscountType.DiffPrdPriceDiscount
                                       group product by product.ProductName into p
                                       select new { ProductName = p.Key, ProductCount = p.Count() } ;
            if (diffDiscountProducts.Count() > 0)
            {
                foreach (var discount in _discountItems)
                {
                    int discountEligibleCount = diffDiscountProducts.Where(w => w.ProductName == discount.EligibleProductName).FirstOrDefault().ProductCount;
                    int discountProductCount = products.Where(p => p.ProductName == discount.DiscountedProductName).Count();                    

                    if (discountProductCount != 0 && discountEligibleCount > 1)
                    {
                        var unitPrice = products.Where(p => p.ProductName == discount.DiscountedProductName).FirstOrDefault().UnitPrice;

                        if (2 * discountProductCount <= discountEligibleCount)
                        {
                            var reducedAmount = UnitCalculator.ApplyDiscount(discountProductCount, unitPrice, discount.DiscountPercentage);
                            msgs.Add
                                (new DiscountMessage
                                {
                                    DiscountAmount = reducedAmount,
                                    Message = $"{discount.DiscountedProductName} {(discount.DiscountPercentage * 100).ToString("0.##")}% off : -{CurrencyFormater.ToCurrencyString(reducedAmount)}"
                                });
                        }
                        else
                        {

                            var reducedAmount = UnitCalculator.ApplyDiscount((discountEligibleCount / 2), unitPrice, discount.DiscountPercentage);
                            msgs.Add
                                (new DiscountMessage
                                {
                                    DiscountAmount = reducedAmount,
                                    Message = $"{discount.DiscountedProductName} {(discount.DiscountPercentage * 100).ToString("0.##")}% off : -{CurrencyFormater.ToCurrencyString(reducedAmount)}"
                                });

                        }
                    }
                }
            }

            return msgs;
        }
    }
}
