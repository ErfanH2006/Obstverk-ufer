using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static obst.Program;

namespace obst
{
    internal class Program
    {
        public class Fruit
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }

            public Fruit(string name, int quantity, decimal price)
            {
                Name = name;
                Quantity = quantity;
                Price = price;
            }
            public class Shop
            {
                private List<Fruit> fruits;

                public Shop()
                {
                    fruits = new List<Fruit>();
                }

                public void AddFruit(string name, int quantity, decimal price)
                {
                    if (quantity < 0)
                    {
                        Console.WriteLine("Quantity cannot be negative.");
                        return;
                    }

                    fruits.Add(new Fruit(name, quantity, price));
                    Console.WriteLine($"{quantity} of {name} added to the shop.");
                }

                public void DisplayFruits()
                {
                    Console.WriteLine("Available Fruits:");
                    foreach (var fruit in fruits)
                    {
                        Console.WriteLine($"{fruit.Name} - {fruit.Quantity} available at ${fruit.Price}");
                    }
                }

                public bool SellFruit(string name, int quantity)
                {
                    var fruit = fruits.Find(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    if (fruit != null && fruit.Quantity >= quantity)
                    {
                        fruit.Quantity -= quantity;
                        Console.WriteLine($"Sold {quantity} of {name}.");
                        return true;
                    }
                    Console.WriteLine($"Not enough {name} available.");
                    return false;
                }

                public List<Fruit> GetFruits()
                {
                    return fruits;
                }
            }

            public class Customer
            {
                public string Name { get; set; }
                public List<(Fruit fruit, int quantity)> Cart { get; private set; }

                public Customer(string name)
                {
                    Name = name;
                    Cart = new List<(Fruit, int)>();
                }
                public void AddToCart(Fruit fruit, int quantity)
                {
                    if (quantity < 0)
                    {
                        Console.WriteLine("Quantity cannot be negative.");
                        return;
                    }

                    Cart.Add((fruit, quantity));
                    Console.WriteLine($"{quantity} of {fruit.Name} added to {Name}'s cart.");
                }
                public void Checkout(Shop shop)
                {
                    decimal total = 0;

                    foreach (var item in Cart)
                    {
                        if (shop.SellFruit(item.fruit.Name, item.quantity))
                        {
                            total += item.fruit.Price * item.quantity;
                        }
                    }

                    Console.WriteLine($"{Name}'s total is: ${total}");
                    Cart.Clear(); // Clear the cart after checkout
                }
            }
            static void Main(string[] args)
            {
                Shop shop = new Shop();
                shop.AddFruit("Aplle", 50, 20000);
                shop.AddFruit("Banana", 100, 60000);


            Customer customer = new Customer("MivehAli");

                bool running = true;

                while (running)
                {
                    Console.WriteLine("\nOptions: 1. View Fruits 2. Add to Cart 3. Checkout 4. Exit");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            shop.DisplayFruits();
                            break;

                        case "2":
                            try
                            {
                                Console.Write("Enter fruit name: ");
                                string fruitName = Console.ReadLine();
                                Console.Write("Enter quantity: ");
                                int quantity = int.Parse(Console.ReadLine());

                                var fruit = shop.GetFruits().Find(f => f.Name.Equals(fruitName, StringComparison.OrdinalIgnoreCase));
                                if (fruit != null)
                                {
                                    customer.AddToCart(fruit, quantity);
                                }
                                else
                                {
                                    Console.WriteLine("Fruit not found.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number for quantity.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                            }
                            break;

                        case "3":



                        customer.Checkout(shop);
                            break;

                        case "4":
                            running = false;
                            break;


                        default:
                            Console.WriteLine("Invalid Option . Try Again .");
                            break;
                    }
                }
            }
        }
    }
}
