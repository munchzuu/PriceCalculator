using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShoppingCart.PriceCalculator.UnitTests
{
    public class DiscountCalculatorTests
    {
        /// <summary>
        /// Test to check the Self Discount product
        /// </summary>
        [Fact]
        public void Self_Discount_ProductTest()
        {
            //Arrange
            string DiscountMsg = "Apples 10% off : -10p";
            var calculatorContext = new SelfDiscountCalculator();
            List<string> products = new List<string>() { "Apples", "Bread", "Milk", "Beans" };

            //Act
            var discount = calculatorContext.CalculateDiscount(new ProductService().AddProductsToBasket(products)).ToList();

            //Assert
            Assert.NotNull(discount);
            Assert.Single(discount);
            foreach (var msg in discount)
            {
                Assert.Equal(DiscountMsg, msg.Message);
            }
        }
        /// <summary>
        /// Test to check the discount message
        /// </summary>
        [Fact]
        public void Discount_MessageTest()
        {
            //Arrange
            var calculatorContext = new SelfDiscountCalculator();
            List<string> products = new List<string>() { "Apples", "Apples", "Apples" };

            //Act
            var discount = calculatorContext.CalculateDiscount(new ProductService().AddProductsToBasket(products)).ToList();
           
            //Assert
            Assert.NotNull(discount);
            Assert.Contains("Apples 10% off :", discount.FirstOrDefault().Message);
        }
        /// <summary>
        /// Test to check half price discount for the items
        /// </summary>
        [Fact]
        public void HalfPriceDiscount_ValueTest()
        {
            //Arrange
            decimal expectedValue = 0.40m;
            var calculatorContext = new HalfPriceDiscountCalculator();
            List<string> products = new List<string>() { "Beans", "Bread", "Beans" };

            //Act
            var discount = calculatorContext.CalculateDiscount(new ProductService().AddProductsToBasket(products)).ToList();
           
            //Assert
            Assert.NotNull(discount);
            Assert.True(discount.Sum(itm => itm.DiscountAmount).Equals(expectedValue));
        }
        /// <summary>
        /// Test to check the discount 
        /// </summary>
        [Fact]
        public void Discount_SameProductValueTest()
        {
            //Arrange
            decimal expectedDiscountValue = 0.30m;
            decimal expectedTotalValue = 3.00m;
            var calculatorContext = new SelfDiscountCalculator();
            ProductService handler = new ProductService();
            List<string> products = new List<string>() { "Apples", "Apples", "Apples" };

            //Act
            var subTotal =handler.SubTotal(handler.AddProductsToBasket(products));
            var discount = calculatorContext.CalculateDiscount(new ProductService().AddProductsToBasket(products)).ToList();        

            //Assert
            Assert.NotNull(discount);
            Assert.True(discount.Sum(itm => itm.DiscountAmount).Equals(expectedDiscountValue));
            Assert.Equal(expectedTotalValue, subTotal);
        }
        /// <summary>
        /// Test to check no discount available for the items
        /// </summary>
        [Fact]
        public void NoDiscount_ProductTest()
        {
            //Arrange
            var calculatorContext = new SelfDiscountCalculator(); 
            List<string> products = new List<string>() { "Beans", "Bread", "Milk", "Bread" };

            //Act
            var discount = calculatorContext.CalculateDiscount(new ProductService().AddProductsToBasket(products)).ToList();            

            //Assert
            Assert.NotNull(discount);
            Assert.Empty(discount);
        }
    }
}
