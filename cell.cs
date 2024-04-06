using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    internal class Cell
    {
        enum fieldType { Property, Action }
        int id;

        public Cell() { id = 4; } // test

        public int getId() { return id; }

    }
}
