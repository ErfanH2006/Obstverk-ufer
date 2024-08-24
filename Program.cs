using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static third.program;

namespace third
{
    internal class program
    {

        class Fruit

        {









            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

            public Fruit(string name, decimal price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public override string ToString()
            {
                return $"{Name} - ${Price:F2} (Quantity: {Quantity})";
            }
        }

        class Program
        {
            static List<Fruit> fruitList = new List<Fruit>();
            static List<Fruit> shoppingCart = new List<Fruit>();

            static void Main(string[] args)
            {
                // Add some initial fruits to the shop
                InitializeFruits();

                Console.WriteLine("Welcome to the Fruit Shop!");
                Console.WriteLine("Choose your role:");
                Console.WriteLine("1. Shop Owner");
                Console.WriteLine("2. Customer");
                Console.Write("Enter your choice (1 or 2): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    ShopOwnerMenu();
                }
                else if (choice == "2")
                {
                    CustomerMenu();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please restart the program.");
                }
            }

            static void InitializeFruits()
            {
                fruitList.Add(new Fruit("Apple", 25000, 10));
                fruitList.Add(new Fruit("Banana", 60000, 20));
                fruitList.Add(new Fruit("Orange", 45000, 15));
                fruitList.Add(new Fruit("Pineapple", 100000, 8));
            }


            static void ShopOwnerMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Shop Owner Menu:");
                    Console.WriteLine("1. Add Fruit");
                    Console.WriteLine("2. Remove Fruit");
                    Console.WriteLine("3. View Fruits");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option: ");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            AddFruit();
                            break;
                        case "2":
                            RemoveFruit();
                            break;
                        case "3":
                            ViewFruits();
                            break;
                        case "4":
                            return; // Exit the menu
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
            }

            static void AddFruit()
            {
                Console.Clear();
                Console.Write("Enter fruit name: ");
                string name = Console.ReadLine();

                Console.Write("Enter fruit price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.Write("Enter fruit quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        var existingFruit = fruitList.Find(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                        if (existingFruit != null)
                        {
                            existingFruit.Quantity += quantity; // Increase quantity
                            Console.WriteLine($"{name} already exists. Increased quantity to {existingFruit.Quantity}.");
                        }
                        else
                        {
                            fruitList.Add(new Fruit(name, price, quantity));
                            Console.WriteLine($"{name} has been added with a price of ${price:F2} and quantity {quantity}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity entered.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid price entered.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            static void RemoveFruit()
            {
                Console.Clear();
                ViewFruits();

                if (fruitList.Count == 0)
                {
                    Console.WriteLine("No fruits available to remove.");
                    return;
                }

                Console.Write("Enter the name of the fruit to remove: ");
                string name = Console.ReadLine(); var fruit = fruitList.Find(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (fruit != null)
                {
                    fruitList.Remove(fruit);
                    Console.WriteLine($"{fruit.Name} has been removed from the shop.");
                }
                else
                {
                    Console.WriteLine("Fruit not found.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            static void ViewFruits()
            {
                Console.Clear();
                Console.WriteLine("Available Fruits:");

                if (fruitList.Count == 0)
                {
                    Console.WriteLine("No fruits available.");
                }
                else
                {
                    foreach (var fruit in fruitList)
                    {
                        Console.WriteLine(fruit);
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            static void CustomerMenu()
            {
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Customer Menu:");
                        Console.WriteLine("1. View Fruits");
                        Console.WriteLine("2. Add to Cart");
                        Console.WriteLine("3. View Cart");
                        Console.WriteLine("4. Checkout");
                        Console.WriteLine("5. Exit");
                        Console.Write("Choose an option: ");

                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                ViewFruits();
                                break;
                            case "2":
                                AddToCart();
                                break;
                            case "3":
                                ViewCart();
                                break;
                            case "4":
                                Checkout();
                                break;
                            case "5":
                                return; // Exit the menu
                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }
                    }
                }
            }

            static void AddToCart()
            {
                Console.Clear();
                ViewFruits();

                if (fruitList.Count == 0)
                {
                    Console.WriteLine("No fruits available to add to the cart.");
                    return;
                }

                Console.Write("Enter the name of the fruit to add to cart: ");
                string name = Console.ReadLine();

                var fruit = fruitList.Find(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (fruit != null && fruit.Quantity > 0)
                {
                    shoppingCart.Add(fruit);
                    fruit.Quantity--; // Decrease quantity in stock
                    Console.WriteLine($"{fruit.Name} has been added to your cart.");
                }
                else
                {
                    if (fruit == null)
                        Console.WriteLine("Fruit not found.");
                    else
                        Console.WriteLine($"Sorry, {fruit.Name} is out of stock.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            static void ViewCart()
            {
                Console.Clear();
                Console.WriteLine("Your Shopping Cart:");

                if (shoppingCart.Count == 0)
                {
                    Console.WriteLine("Your cart is empty.");
                }
                else
                {
                    foreach (var fruit in shoppingCart)
                    {
                        Console.WriteLine(fruit);
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            static void Checkout()
            {
                decimal total = 0;

                if (shoppingCart.Count == 0)
                {
                    Console.WriteLine("Your cart is empty. Cannot proceed to checkout.");
                    return;
                }

                foreach (var fruit in shoppingCart)
                {
                    total += fruit.Price;
                }

                Console.Clear();
                Console.WriteLine($"Your total is: ${total:F2}");

                shoppingCart.Clear(); // Clear the cart after checkout
                Console.WriteLine("Thank you for your purchase!");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}