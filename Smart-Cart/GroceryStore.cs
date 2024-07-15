using System;
using System.Collections.Generic;

namespace ShoppingCartApplication
{
    public class GroceryStore : IStore
    {
        private ProductGenerator productGenerator;
        public List<Product> FoodProducts { get; private set; }

        public GroceryStore()
        {
            productGenerator = new ProductGenerator();
            FoodProducts = new List<Product>();
        }

        public void FillProducts(int numberOfProducts)
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                Product foodProduct = productGenerator.GenerateFoodProduct();
                FoodProducts.Add(foodProduct);
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Food Products:");
            foreach (var product in FoodProducts)
            {
                Console.WriteLine($"{product.Name}, {product.Price:C}");
            }
        }

        public Product GetProductByNumber(int productNumber)
        {
            if (productNumber <= 0 || productNumber > FoodProducts.Count)
            {
                Console.WriteLine($"Invalid product number: {productNumber}");
                return null;
            }
            return FoodProducts[productNumber - 1];
        }
    }
}
