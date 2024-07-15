using System;
using System.Collections.Generic;

namespace ShoppingCartApplication
{
    public class ElectronicStore : IStore
    {
        private ProductGenerator productGenerator;
        public List<Product> ElectronicProducts { get; private set; }

        public ElectronicStore()
        {
            productGenerator = new ProductGenerator();
            ElectronicProducts = new List<Product>();
        }

        public void FillProducts(int numberOfProducts)
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                Product electronicProduct = productGenerator.GenerateElectronicProduct();
                ElectronicProducts.Add(electronicProduct);
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Electronic Products:");
            foreach (var product in ElectronicProducts)
            {
                Console.WriteLine($"{product.Name}, {product.Price:C}");
            }
        }

        public Product GetProductByNumber(int productNumber)
        {
            if (productNumber <= 0 || productNumber > ElectronicProducts.Count)
            {
                Console.WriteLine($"Invalid product number: {productNumber}");
                return null;
            }

            return ElectronicProducts[productNumber - 1];
        }
    }
}
