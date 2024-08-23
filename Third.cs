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
            public string Name;
            public int Quantity;
            public int Price;
            public Fruit(string Name, int Quantity, int Price)
            {
                this.Name = name;
                this.Quantity = quantity;
                this.Price = price;
            }
        }
        public class Shop
        {
            private list<Fruit> fruits;
            public Shop()
            {
                fruits = new list<Fruit>();
            }
            public void AddFruit(string name, int quantity, int price)
            {
                fruits.Add(new Fruit(name, quantity, price));
                Console.WriteLine($"{quantity} of {name} added to the shop .");
            }
            public void DisplayFruits()
            {
                Console.WriteLine(" available fruits : ");
                foreach (var fruit in fruits)
                {
                    Console.Writeline($"{Fruit.name} - {Fruit.quantity} available at {Fruit.price}")
                }
            }
            public bool SellFruit(string name, int quantity)
            {
                var fruit = fruits.Find(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (fruit != null && fruit.Quantity >= quantity)
                {
                    fruit.Quantity -= quantity;
                    Console.WriteLine($"{quantity} of {name} .");
                    return true;
                }
                Console.WriteLine($"not enough {name} available");
                return false;
            }
            public List<Fruit> Getfruits()
            {
                return fruits;
            }
            public class Customer
            {
                public string Name { get; set; }
                public List<Fruit fruit, int quantity> Cart { get; set; }
            }
            public Customer(string name)
            {
                Name = name;
                Cart = new List<Fruit, int>();
            }
            public void AddTooCart(Fruit fruit, int quantity)
            {
                if (quantity < 0)
                {
                    Console.WriteLine("Quantity cannot be negative.");
                    return;
                }
                Cart.Add(fruit, quantity);
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
            shop.AddFruit(Aplle , 50 , 20000)
            shop.AddFruit(Banana, 100 , 60000)

            Customer customer = new Customer("MivehAli");
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nOptions: 1. View Fruits 2. Add to Cart 3. Checkout 4. Exit");
                var choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1"
                        
                        Shop.DisplayFruits();
                        break;
                        
                    case "2"
                        try
                        {
                            Console.Write("Enter fruit name: ");
                            string fruitName = Console.ReadLine();
                            Console.Write("Enter quantity: ");
                            int quantity = int.Parse(Console.ReadLine());
                            var fruit = shop.Getfruits();
                            Find(f => f.Name.Equals(fruitName, StringComparison.OrdinalIgnoreCase));
                            if (fruit != null)
                            {
                                customer.AddToCart(fruit, quantity);
                            }
                            else
                            {
                                Console.Writeline("fruit not found");
                            }
                        }
                        catch (FormatException) 
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number for quantity.");
                        }
                            break;
                        
                    case "3"
                        
                        shop.Checkout(shop);
                        break;
                     
                    case "4"
                        running = false;
                        break;


                    default:
                        Console.WriteLine("Invalid Option . Try Again .");
                        break;
                }
            }
    }
}
