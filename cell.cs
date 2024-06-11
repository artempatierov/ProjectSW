using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Cell
    {
        public enum fieldType { Property, Action, Chance, Chest, Tax }

        fieldType type;
        int id;
        PictureBox field;
        Property propertyInfo;

        public Cell(int id)
        {
            var ui = WindowsFormsApp1.GUI.UI;
            //var pr_Manager = PropertyManager.m_propertyManager;

            this.id = id;
            if (id == 0 || id == 10 || id == 20 || id == 30 )
            {
                type = fieldType.Action;

            } else if (id == 7 || id == 22 || id == 36)
            {
                type = fieldType.Chance;
            } else if (id == 2 || id == 17 || id == 33)
            {
                type = fieldType.Chest;
            } else if (id == 4 || id == 38)
            { 
                type = fieldType.Tax; 
            } else
            {
                type = fieldType.Property;
                propertyInfo = null;
            }
            field = Extensions.GetElementByTabIndex(id);
        }

        public void setPropertyInfo(Property property)
        {
            this.propertyInfo = property;
        }

        public int getId() { return id; }
        public PictureBox getField() { return field; }

        public fieldType getCellType() { return type; } 

    }
}
