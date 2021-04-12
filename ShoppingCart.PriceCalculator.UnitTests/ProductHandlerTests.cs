using ShoppingCart.PriceCalculator.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShoppingCart.PriceCalculator.UnitTests
{
    public class ProductServiceTests
    {
        /// <summary>
        /// Test to check the total price of the products
        /// </summary>
        [Fact]
        public void SubTotal_AllProduct_MatchingTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            decimal expectedSubTotal = 3.90m;
            List<string> products = new List<string>() { "Milk", "Apples", "Bread", "Bread" };

            // Act
            var subTotal = handler.SubTotal(handler.AddProductsToBasket(products));

            //Assert            
            Assert.Equal(expectedSubTotal, subTotal);
        }
        /// <summary>
        /// Test to check if  all the product are not available then the total price is zero
        /// </summary>
        [Fact]
        public void SubTotal_AllProduct_NotMatchingTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            List<string> products = new List<string>() { "Orange", "Mango", "Cherry", "Egg" };

            // Act
            var subTotal = handler.SubTotal(handler.AddProductsToBasket(products));

            //Assert
            Assert.True(subTotal == 0);
        }
        /// <summary>
        /// Test to check all the items in the basket are available.
        /// </summary>
        [Fact]
        public void AllProduct_MatchingTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            List<string> products = new List<string>() { "Milk", "Apples", "Bread", "Bread" };

            //Act
            IEnumerable<Product> productlst = handler.AddProductsToBasket(products);

            //Assert
            Assert.NotNull(productlst);
            Assert.Equal(4, productlst.ToList().Count());
        }
        /// <summary>
        /// Test to check the product available is empty for the given unavailable items.
        /// </summary>
        [Fact]
        public void AllProduct_NotMatchingTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            List<string> products = new List<string>() { "Ball", "Bat", "Mango", "Orange" };

            //Act
            IEnumerable<Product> productlst = handler.AddProductsToBasket(products);

            //Assert
            Assert.NotNull(productlst);
            Assert.Empty(productlst.ToList());
        }

        [Fact]
        public void OneProduct_NotMatchingTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            List<string> products = new List<string>() { "Milk", "Apples", "Bread", "Orange" };

            //Act
            IEnumerable<Product> productlst = handler.AddProductsToBasket(products);

            //Assert
            Assert.NotNull(productlst);
            Assert.Equal(productlst.Count() + 1, products.Count);
        }
        /// <summary>
        /// Test to check Camelcase inputs
        /// </summary>
        [Fact]
        public void Product_UpperLowerCaseTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            List<string> products = new List<string>() { "milk", "apples", "BREAD", "BEANS" };

            //Act
            IEnumerable<Product> productlst = handler.AddProductsToBasket(products);

            //Assert
            Assert.NotNull(productlst);
            Assert.Equal(productlst.Count(), products.Count);
        }
        /// <summary>
        /// Test to check empty basket
        /// </summary>
        [Fact]
        public void EmptyProductListTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            List<string> products = new List<string>();

            //Act
            IEnumerable<Product> productlst = handler.AddProductsToBasket(products);

            //Assert
            Assert.NotNull(productlst);
            Assert.Empty(productlst);
        }
        /// <summary>
        /// Test to check empty item names.
        /// </summary>
        [Fact]
        public void EmptyStringListTest()
        {
            // Arrange 
            ProductService handler = new ProductService();
            List<string> products = new List<string>() { "", "Apples", "Bread", "" };

            //Act
            IEnumerable<Product> productlst = handler.AddProductsToBasket(products);

            //Assert
            Assert.NotNull(productlst);
            Assert.Equal(2, productlst.Count());
        }
    }


}
