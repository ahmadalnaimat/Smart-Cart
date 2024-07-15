using Xunit;
using ShoppingCartApplication;

namespace ShoppingCartApplication.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void AddToCart_ShouldIncreaseTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            var product = new Product("TestProduct", 10.0m);

            // Act
            cart.Add(product);

            // Assert
            Assert.Equal(10.0m, cart.Total);
            Assert.Contains(product, cart.items);
        }

        [Fact]
        public void RemoveFromCart_ShouldDecreaseTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            var product = new Product("TestProduct", 10.0m);
            cart.Add(product);

            // Act
            cart.Remove(product.ProductNumber);

            // Assert
            Assert.Equal(0.0m, cart.Total);
            Assert.DoesNotContain(product, cart.items);
        }
    }
}
