using System;

namespace ShoppingCart.PriceCalculator.Model
{
    /// <summary>
    /// Product property which holds the actual products
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique number applied to all products
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Name of the Product availabe in the shop
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Price of each product
        /// </summary>
        public Decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount types for each product availabe in the shop, defaults to no discount
        /// </summary>
        public ProductDiscountType DiscountType { get; set; } = ProductDiscountType.NoDiscount;        
    }
}
