﻿using System;
using System.Collections.Generic;

namespace ShoppingCartApplication
{
    public class ClothingStore : IStore
    {
        private ProductGenerator productGenerator;
        public List<Product> ClothingProducts { get; private set; }

        public ClothingStore()
        {
            productGenerator = new ProductGenerator();
            ClothingProducts = new List<Product>();
        }

        public void FillProducts(int numberOfProducts)
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                Product clothingProduct = productGenerator.GenerateClothingProduct();
                ClothingProducts.Add(clothingProduct);
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Clothing Products:");
            foreach (var product in ClothingProducts)
            {
                Console.WriteLine($"{product.Name}, {product.Price:C}");
            }
        }

        public Product GetProductByNumber(int productNumber)
        {
            if (productNumber <= 0 || productNumber > ClothingProducts.Count)
            {
                Console.WriteLine($"Invalid product number: {productNumber}");
                return null;
            }
            return ClothingProducts[productNumber - 1];
        }
    }
}
