using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class PropertyManager
    {
        public static PropertyManager m_PropertyManager { get; private set; }
        public static Property[] properties= new Property[22];//40 pol - 4 kwadraty - 8 do oplaty, 3xSkrzynka, 3xSzansa
        public static string[] nazwy = Extensions.GetPropNameTable();//22 elem. tablica nazw
        public PropertyManager()
        {
            //fill Properties
            m_PropertyManager = this;
            for (int i = 0; i < 22; i++)
            {
                properties[i] = new Property(i, nazwy[i], i * 50 + i * 100 / 2, -1);
            }
        }

        public Property findPropertyById(int propertyId)
        {
            Console.WriteLine("findPropertyById: " + propertyId);
            return properties[propertyId];
        }
    }
}
