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
            Action.GoTo(0, 0);
            Action.GoTo(1, 0);
            Action.GoTo(2, 0);
            Action.GoTo(3, 0);
        }

        public void GoTo(System.Windows.Forms.PictureBox user, System.Windows.Forms.PictureBox cell)
        {
            int x = cell.Location.X;
            int y = cell.Location.Y;
            string name = user.Name;
            switch (name)
            {
                case "bot_1":
                    x += 30;
                    break;
                case "bot_2":
                    y += 30;
                    break;
                case "bot_3":
                    x += 30;
                    y += 30;
                    break;
                default:
                    Console.WriteLine("UI:GoTo user: " + user.Name + " to position: " + cell.Name);
                    break;
            }
            user.Location = new Point(x, y);
        }
        private void dice_Click(object sender, EventArgs e)
        {
            int wynik= Action.RollDice();
            var p_Manager = PlayersManager.m_playersManager;
            //var b_Manager = BoardManager.m_boardManager;
            Player user = p_Manager.findPlayerById(0);
            user.cellId += wynik;
            user.cellId %= 40;
            Action.GoTo(user.getId(), user.cellId);//TODO wyciągnięcie PlayerId oraz dodać wynik do CellId
            String wynik_txt=wynik.ToString();
            MessageBox.Show(wynik_txt);
        }
    }
}
