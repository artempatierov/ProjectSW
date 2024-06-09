using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public static class Extensions
    {
        public static System.Windows.Forms.PictureBox GetElementByTabIndex(int index)
        {
            var ui = WindowsFormsApp1.GUI.UI;
            foreach (Control control in ui.Controls)
            {
                if (control.TabIndex == index)
                {
                    return control as PictureBox;
                }
            }
            return null;
        }

        public static Label GetLabelByName(string name)//przepatruje kontrolki w poszukiwaniu odpowiedniej po zmiennej Name
        {
            var ui = GUI.UI;
            foreach (Control control in ui.Controls)
            {
                if (control.Name == name)
                {
                    return control as Label;
                }
            }
            return null;
        }

        public static void LoadMoney()
        {
            var p_Manager = PlayersManager.m_playersManager;
            string name = "money";
            for (int i = 0; i < 4 ; i++)
            {
                Label money = GetLabelByName(name + (i+1).ToString());
                Player user = p_Manager.findPlayerById(i);
                money.Text = user.getMoney().ToString();
            }
        }
        //Potrzebuję wyciągnąć Label.Text i przypisać do nazwy Property
        public static string[] GetPropNameTable()
        {
            string[] property_names = new string[22];
            string name = "property";
            for (int i = 0; i < 22; i++)
            {
                Label property_number = GetLabelByName(name + (i + 1).ToString());//znajdz property Label po kontrolce label.name
                property_names[i] = property_number.Text;
            }
            return property_names;
        }
    }
}
