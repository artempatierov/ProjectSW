using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Cell
    {
        enum fieldType { Property, Action }
        int id;
        PictureBox field;

        public Cell(int id)
        {
            var ui = WindowsFormsApp1.GUI.UI;
            this.id = id;
            field = Extensions.GetElementByTabIndex(id);
        }

        public int getId() { return id; }
        public PictureBox getField() { return field; }

    }
}
