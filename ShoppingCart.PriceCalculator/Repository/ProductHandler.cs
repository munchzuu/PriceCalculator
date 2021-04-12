using ShoppingCart.PriceCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.PriceCalculator.Repository
{
    class ProductHandler : IProductHandler
    {
        public readonly List<Product> _items;
        /// <summary>
        /// This contructor sets the constant products, this canbe set to load it from DB or other source
        /// </summary>
        public ProductHandler()
        {
            _items = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Beans", UnitPrice = 0.65m, DiscountType = ProductDiscountType.DiffPrdPriceDiscount },
                new Product { ProductId = 2, ProductName = "Bread", UnitPrice = 0.80m , DiscountType = ProductDiscountType.NoDiscount},
                new Product { ProductId = 3, ProductName = "Milk", UnitPrice = 1.30m , DiscountType = ProductDiscountType.NoDiscount},
                new Product { ProductId = 4, ProductName = "Apples", UnitPrice = 1.00m , DiscountType = ProductDiscountType.SelfPrdPriceDiscount}
            };
        }
        /// <summary>
        /// This method converts the list of arguments into availabe product list 
        /// </summary>
        /// <param name="products">List of input product items</param>
        /// <returns>Available Products</returns>
        public IEnumerable<Product> AddProductsToBasket(IEnumerable<string> products)
        {
            List<Product> basketItems = new List<Product>();
            try
            {
                foreach (string prd in products)
                {
                    if (_items.Exists(itm => itm.ProductName.ToLowerInvariant() == prd.ToLowerInvariant()))
                    {
                        basketItems.Add(_items.FirstOrDefault(p => p.ProductName.ToLowerInvariant() == prd.ToLowerInvariant()));
                    }
                }
            }
            catch
            {
                //if required, we can catch the exeption object and log it here
                throw;
            }
            return basketItems;
        }
        /// <summary>
        /// This method total all the product price
        /// </summary>
        /// <param name="products">List of product items</param>
        /// <returns>Sum of unit price</returns>
        public Decimal SubTotal(IEnumerable<Product> products)
        {
            return products.Sum(item => item.UnitPrice);
        }
    }
}
