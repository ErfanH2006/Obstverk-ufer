using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            public class Fruit {
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
            public void AddFruit(string name , int quantity , int price) {
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
                    if ( fruit != null && fruit.Quantity >= quantity) 
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
        }
    }
}
