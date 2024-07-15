using System;
using System.Threading;

namespace ShoppingCartApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStore foodStore = new GroceryStore();
            IStore clothingStore = new ClothingStore();
            IStore electronicStore = new ElectronicStore();
            ShoppingCart shoppingCart = new ShoppingCart();
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("[1] Grocery Store\n[2] Clothing Store\n[3] Electronic Store\n[4] Shopping Cart\n[5] Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int ans))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (ans)
                {
                    case 1:
                        int numberOfFoodProductsToAdd = 5;
                        foodStore.FillProducts(numberOfFoodProductsToAdd);
                        foodStore.DisplayProducts();
                        AddProductsToCart(foodStore, shoppingCart);
                        break;
                    case 2:
                        int numberOfClothingToAdd = 5;
                        clothingStore.FillProducts(numberOfClothingToAdd);
                        clothingStore.DisplayProducts();
                        AddProductsToCart(clothingStore, shoppingCart);
                        break;
                    case 3:
                        int numberOfElectronicProductsToAdd = 5;
                        electronicStore.FillProducts(numberOfElectronicProductsToAdd);
                        electronicStore.DisplayProducts();
                        AddProductsToCart(electronicStore, shoppingCart);
                        break;
                    case 4:
                        shoppingCart.DisplayCart();
                        RemoveFromCart(shoppingCart);
                        break;
                    case 5:
                        loop = false;
                        Console.WriteLine("Thank you for shopping!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }

                Thread.Sleep(2000);
                Console.Clear();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void AddProductsToCart(IStore store, ShoppingCart cart)
        {
            Console.WriteLine($"Enter the product number(s) to add to the cart (comma-separated) Press enter to Exit:");
            string input = Console.ReadLine();

            string[] productNumbers = input.Split(',');
            foreach (string number in productNumbers)
            {
                if (int.TryParse(number.Trim(), out int productNumber))
                {
                    Product product = store.GetProductByNumber(productNumber);

                    if (product != null)
                    {
                        cart.Add(product);
                        Console.WriteLine($"Added '{product.Name}' to the cart.");
                    }
                    else
                    {
                        Console.WriteLine($"Product with number {number} not found in {store.GetType().Name}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input: {number}. Skipping.");
                }
            }
        }

        static void RemoveFromCart(ShoppingCart cart)
        {
            Console.WriteLine("Enter the product index(es) to remove from the cart (comma-separated) Press enter to Exit:");
            string input = Console.ReadLine();

            string[] productIndexes = input.Split(',');
            foreach (string indexString in productIndexes)
            {
                if (int.TryParse(indexString.Trim(), out int productIndex))
                {
                    cart.Remove(productIndex - 1);
                }
                else
                {
                    Console.WriteLine($"Invalid input: {indexString}. Skipping.");
                }
            }
        }
    }
}
