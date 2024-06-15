using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public abstract class Property
    {
        protected string name;
        protected int price;
        protected int level;
        protected string player;

        public Property(string name, int price, int level, string player)
        {
            this.name = name;
            this.price = price;
            this.level = 0;
            this.player = "none";
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Player: {player}");
        }

        public void Buy(Property property, Player player)
        {
            if (property.player == "none")
            {
                Console.WriteLine($"Do you want to buy this property? (y/n)");
                Console.ReadLine();
                if (player.money>price)
                {
                    Console.WriteLine($"You bought this property");
                    property.player = player.name;
                }
            }
        }
        
        public void Upgrade(Player player)
        {
            if (player.money > (price / 2))
            {
                player.money = player.money - (price / 2);
                level++;
                Console.WriteLine($"{name} has been upgraded to level {level}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money!");
            }
        }

        public int Pay_rent(Property property)
        {
            int rent;
            rent = (property.price / 2) + (property.price * level);
        }
    }
    public class F1 : Property
    {
        public F1() : base("Mediterranean Avenue", 200)
        {
        }
    }

}
