using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    internal class action
    {
        public static void GoTo(int x)
        {
            Console.WriteLine("GoTo");
            var ui = WindowsFormsApp1.GUI.UI;
            ui.GoTo();
        }
    }
}
