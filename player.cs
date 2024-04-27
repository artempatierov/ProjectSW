using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Player
    {
        int id;
        public float money;
        public int cellId = 0;
        int doubletCount = 0;
        int inJail = 0;

        public Player(int id) 
        { 
            this.id = id;
            setMoney(1500);
        }
        public int getId() { return id; }

        public float getMoney() { return money;}
        public int getCellId() {  return cellId;}

        void setMoney(int amount) {  money = amount; }
        public void addMoney(int amount) { money += amount; }

        public int getDoubletCount() {  return doubletCount; }

        public void setDoubletCount(int count) {  doubletCount = count; }

        public void addDoublet() {  doubletCount++; }

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

    }
}
