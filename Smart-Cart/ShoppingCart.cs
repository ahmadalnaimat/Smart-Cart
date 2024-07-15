using System;
using System.Collections.Generic;

namespace ShoppingCartApplication
{
    public class ShoppingCart
    {
        public List<Product> items;

        public ShoppingCart()
        {
            items = new List<Product>();
        }

        public decimal Total { get; private set; }

        public void Add(Product product)
        {
            items.Add(product);
            Total += product.Price;
        }

        public void Remove(int productIndex)
        {
            if (productIndex < 0 || productIndex >= items.Count)
            {
                Console.WriteLine($"Invalid product index '{productIndex}'. Please select a valid number.");
                return;
            }

            Product productToRemove = items[productIndex];
            Total -= productToRemove.Price;
            items.RemoveAt(productIndex);
            Console.WriteLine($"Removed '{productToRemove.Name}' from the cart.");
        }

        public void DisplayCart()
        {
            Console.WriteLine("Shopping Cart:");

            if (items.Count == 0)
            {
                Console.WriteLine("Your shopping cart is empty.");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    int displayNumber = i + 1;

                    Console.WriteLine($"[{displayNumber}] {items[i].Name}, {items[i].Price:C}");
                }
            }
        }
    }
}
