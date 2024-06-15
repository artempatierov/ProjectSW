﻿using System;
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
        double rent;
        Label label;

        public Property(int id,string name, double price)
        {
            this.id= id;
            this.name = name;
            this.price = price;
            this.upgrade_level = 0;
            this.upgrade_price = price * 0.50;
            this.player_owner_id = -1;
            this.rent = price*0.10;
            int tabLabelId = id + 100;
            label = Extensions.GetLabelByTabId(tabLabelId);
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
        public void setPropUpgradePrice()
        {
            price = this.price * 1.20;
            this.upgrade_price = price * 0.50;
            this.rent = price * 0.10;
        }


        public int getPlayerOwnerId() { return player_owner_id; }
        public void setPlayerOwnerId(int i) { player_owner_id = i; }


        public bool getVisible(Label label) { return label.Visible; }
        public void setVisible(bool yay_or_nay)
        {
            if (label != null)
            { label.Visible = yay_or_nay; }
        }

        public double getRentPrice()
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();

            if (property.getPropId() == 3 || property.getPropId() == 11 || property.getPropId() == 19 || property.getPropId() == 26)
            {
                rent = 100 * user.getRailroad();
                return rent;
            }
            if (property.getPropId() == 8 || property.getPropId() == 21)
            {
                Random random = new Random();
                int kosc_1 = random.Next(1, 6);
                int kosc_2 = random.Next(1, 6);
                rent = kosc_1 + kosc_2;
                return rent;
            }
            else
            {
                rent = property.rent;
                return rent;
            }
        }
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