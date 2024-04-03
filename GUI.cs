using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonopolyGame;

namespace WindowsFormsApp1
{
    public partial class GUI : Form
    {
        public static GUI UI { get; private set; }
        public GUI()
        {
            InitializeComponent();
            UI = this;
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            action.GoTo(1);
        }

        public void GoTo()
        {
            //Gracz.Location = Start.Location;
        }
    }
}
