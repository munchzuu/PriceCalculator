using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.PriceCalculator.Model
{
    /// <summary>
    /// Enum for the types of discount applied to eligible products
    /// </summary>
    public enum ProductDiscountType
    {
        SelfPrdPriceDiscount,
        DiffPrdPriceDiscount,
        ProductCountDiscount,
        NoDiscount
    }
}
