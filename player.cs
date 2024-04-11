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

        public Player(int id) 
        { 
            this.id = id;
            money = 1500;
        }
        public int getId() { return id; }
    }
}
