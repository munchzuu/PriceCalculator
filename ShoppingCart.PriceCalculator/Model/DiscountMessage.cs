using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.PriceCalculator.Model
{
    /// <summary>
    /// This holds the offer message of each discounted products
    /// </summary>
    public class DiscountMessage
    {
        /// <summary>
        /// Discounted price of each item
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Message to display in the screen
        /// </summary>
        public string Message { get; set; }
    }
}
