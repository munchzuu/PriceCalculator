using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.PriceCalculator.Util
{
    /// <summary>
    /// Format the currency in pounds and pense
    /// </summary>
    public class CurrencyFormater
    {
        /// <summary>
        /// This method returns the currecy type whether it is a pense or pounds.
        /// </summary>
        /// <param name="value">value of the current</param>
        /// <returns>Returns the converted current type</returns>
        public static string ToCurrencyString(decimal value)
        {
            return value < 1 ? $"{(int)(value * 100)}p" : $"{value:C}";
        }
    }

    /// <summary>
    /// This class helps to apply the discounts on the given quantity
    /// </summary>
    public static class UnitCalculator
    {
        /// <summary>
        /// This private method will perform the Math calculation and returns the product cost
        /// </summary>
        /// <param name="quantity">Number of item</param>
        /// <param name="unitPrice">Prie of each item</param>
        /// <param name="percentage">Discount value</param>
        /// <returns>returns discounted product value</returns>
        public static decimal ApplyDiscount(int quantity, decimal unitPrice, decimal percentage)
        {
            return Math.Round((unitPrice * quantity) * percentage, 2);
        }
    }
}
