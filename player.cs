using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Player
    {
        int id;
        public double money;
        public int cellId = 0;
        int doubletCount = 0;
        int inJail = 0;
        public string name;
        int railroad = 0;

        public Player(int id) 
        { 
            this.id = id;
            setMoney(1500);
            setName(id);
            cellId = 0;
        }
        public int getId() { return id; }

        public double getMoney() { return money;}
        public int getCellId() {  return cellId;}
        public string getName() { return name;}
        public void setName(int id) {
            if (id == 0)
            {
                name = "Mr. Smith";
            }
            else if (id == 1)
            {
                name = "Gov. Richmount";
            }
            else if (id == 2)
            {
                name = "Gen. Winchester";
            }
            else if (id == 3)
            {
                name = "Mr. Goldberg";
            };
        }

        public void setMoney(double amount) {  money = amount; }
        public void addMoney(double amount) { money += amount; }

        public void removeMoney(double amount) {
            if (this.getMoney() < amount)
            {
                string info = "Przegrałeś " + this.getName();
                MessageBox.Show(info, "", MessageBoxButtons.OK);
                if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.removeMoney(amount);
                }
                else
                {
                    Action.Endgame();
                    return;
                }
            }
            money -= amount; 
        }

        public int getDoubletCount() {  return doubletCount; }

        public void setDoubletCount(int count) {  doubletCount = count; } 

        public void addDoublet() {  doubletCount++; }

        public void setCellId(int id) { cellId = id; }

        public int getInJail() {  return inJail; }

        public void setInJail() { inJail = 2; }

        public bool decreseJail()
        {
            if (inJail > 0)
            {
                inJail--;
                return true;
            }
            return false;
        }
        public void addFreeJailExit()
        {
            inJail--;
        }
        public void increaseJail()
        {
            inJail++;
        }

        public int getRailroad() { return railroad; }
        public void setRailroad() { railroad += 1; }
    }
}
