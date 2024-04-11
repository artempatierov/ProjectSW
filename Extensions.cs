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
    }
}
