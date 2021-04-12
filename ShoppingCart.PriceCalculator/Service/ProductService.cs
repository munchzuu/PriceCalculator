using ShoppingCart.PriceCalculator.Model;
using ShoppingCart.PriceCalculator.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.PriceCalculator
{

    public class ProductService
    {
        private readonly IProductHandler _productHandler;

        /// <summary>
        /// This contructor invokes the product and discount services
        /// </summary>
        public ProductService()
        {
            _productHandler = new ProductHandler();
            
        }

        /// <summary>
        /// This method calls the product service to convert the list of items into availabe product 
        /// </summary>
        /// <param name="products">List of product items</param>
        /// <returns>Available Products</returns>
        public IEnumerable<Product> AddProductsToBasket(IEnumerable<string> products) => _productHandler.AddProductsToBasket(products);

        /// <summary>
        /// This method calculate the total amount of the product value before applying any discounts
        /// </summary>
        /// <param name="products">List of product items</param>
        /// <returns>Total price of available products</returns>
        public decimal SubTotal(IEnumerable<Product> products) => _productHandler.SubTotal(products);
    }
}
