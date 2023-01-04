using System;
using System.Collections.Generic;

namespace ShoppingCartConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddItem("apple", 2);
            cart.AddItem("banana", 3);
            cart.AddItem("orange", 1);

            double total = cart.GetTotal();

            Console.WriteLine($"Total: ${total}");

        }
    }
    public class ShoppingCart
    {
        private Dictionary<string, int> items;

        public ShoppingCart()
        {
            items = new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetItems()
        {
            return items;
        }

        public void AddItem(string item, int quantity)
        {
            if (items.ContainsKey(item))
            {
                items[item] += quantity;
            }
            else
            {
                items.Add(item, quantity);
            }
        }

        public void RemoveItem(string item, int quantity)
        {
            if (items.ContainsKey(item))
            {
                items[item] -= quantity;

                if (items[item] <= 0)
                {
                    items.Remove(item);
                }
            }
        }

        public int GetQuantity(string item)
        {
            if (items.ContainsKey(item))
            {
                return items[item];
            }

            return 0;
        }

        public double GetTotal()
        {
            double total = 0;

            foreach (KeyValuePair<string, int> item in items)
            {
                total += item.Value * GetPrice(item.Key);
            }

            return total;
        }

        private double GetPrice(string item)
        {
            switch (item)
            {
                case "apple":
                    return 0.99;
                case "banana":
                    return 0.59;
                case "orange":
                    return 0.89;
                default:
                    return 0;
            }
        }
    }
}


