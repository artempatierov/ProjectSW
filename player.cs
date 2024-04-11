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

        public Player(int id,float money) 
        { 
            this.id = id;
            this.money = 1500;
        }
        public int getId() { return id; }
    }
}
