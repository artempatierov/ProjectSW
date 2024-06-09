using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    internal class Property
    {
        int id;
        string name;
        double price;
        int upgrade_level;
        double upgrade_price;
        int player_owner_id;
        Label label;

        public Property(int id,string name, double price, int player_owner_id)
        {
            this.id= id;
            this.name = name;
            this.price = price;
            this.upgrade_level = 0;
            this.upgrade_price = price * 0.15;
            this.player_owner_id = -1;
        }

        public int getPropId() { return id; }
        public void setPropId(int i) { id = i; }

        public string getPropName() { return name; }
        public void setPropName(string s) { name = s; }


        public double getPropPrice() { return price; }
        public void setPropPrice(double ds) { price = ds; }//;)


        public int getUpgradeLevel() { return upgrade_level; }
        public void bumpUpUpgradeLevel(int i) { upgrade_level++; }


        public double getPropUpgradePrice() { return upgrade_price; }
        public void setPropUpgradePrice() { upgrade_price = this.price * 0.25; }


        public int getPlayerOwnerId() { return player_owner_id; }
        public void setPlayerOwnerId(int i) { player_owner_id = i; }


        public bool getVisible(Label label) { return label.Visible; }
        public void setVisible(bool yay_or_nay) { label.Visible= yay_or_nay; }
        /*
                public void Buy(Property property, Player player)
                {
                    if (property.player == "none")
                    {
                        Console.WriteLine($"Do you want to buy this property? (y/n)");
                        Console.ReadLine();
                        if (player.money > price)
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
        */
    }
}