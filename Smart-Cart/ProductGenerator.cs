using System;

namespace ShoppingCartApplication
{
    public class ProductGenerator
    {
        private static readonly Random random = new Random();
        private static readonly string[] foodProductNames = { "Apple", "Banana", "Carrot", "Bread", "Milk" };
        private static readonly string[] clothingProductNames = { "Shirt", "Pants", "Jacket", "Shoes", "Hat" };
        private static readonly string[] electronicProductNames = { "Phone", "Laptop", "Headphones", "Monitor", "Keyboard" };

        public Product GenerateFoodProduct()
        {
            return new Product(foodProductNames[random.Next(foodProductNames.Length)], random.Next(1, 100));
        }

        public Product GenerateClothingProduct()
        {
            return new Product(clothingProductNames[random.Next(clothingProductNames.Length)], random.Next(10, 200));
        }

        public Product GenerateElectronicProduct()
        {
            return new Product(electronicProductNames[random.Next(electronicProductNames.Length)], random.Next(50, 1000));
        }
    }
}
