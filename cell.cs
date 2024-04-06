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
        System.Windows.Forms.PictureBox field;

        public Cell(int id)
        {
            var ui = WindowsFormsApp1.GUI.UI;
            this.id = id;
            field = Extensions.GetElementByTabIndex(id);
        }

        public int getId() { return id; }

    }
}
