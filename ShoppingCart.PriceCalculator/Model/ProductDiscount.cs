using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.PriceCalculator.Model
{
    /// <summary>
    /// This class property holds the Product discount values and types 
    /// Most of the discounts are covered in this class property,
    /// we can split this into multiple class prop for each discount type and use it in the code.
    /// </summary>
    class ProductDiscount
    {
        /// <summary>
        /// Eligible product name to check the basket items
        /// </summary>
        public string EligibleProductName { get; set; }  
        
        /// <summary>
        /// Discounting product name
        /// </summary>
        public string DiscountedProductName { get; set; }

        /// <summary>
        /// Amount of discount applied
        /// </summary>
        public Decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Time items added into Basket
        /// </summary>        
        public DateTime CreatedDate { get; } = DateTime.Now.ToUniversalTime();

        /// <summary>
        /// Expiry if we need to use it later
        /// </summary>
        public DateTime ExpireDate { get; } = DateTime.Now.AddDays(1).ToUniversalTime();
    }
}
