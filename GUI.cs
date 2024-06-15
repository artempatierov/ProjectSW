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
            Extensions.LoadMoney();
        }

        public void GoToGui(System.Windows.Forms.PictureBox user, System.Windows.Forms.PictureBox cell)
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
            Action.ProcessMove();
        }

        private void info_Click(object sender, EventArgs e)
        {
            Action.PrintDetails();
        }

        private void buy_Click(object sender, EventArgs e)
        {
            Action.BuyProperty();
        }
        private void property1_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property2_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property4_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property5_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property6_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property7_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property9_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property10_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property12_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property13_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property14_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property15_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property16_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property17_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property18_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property20_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property22_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property23_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property24_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property25_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property27_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }

        private void property28_Click(object sender, EventArgs e)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            string info = "Ulepszyć za " + property.getPropUpgradePrice();
            if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Action.UpgradeProperty();
            }
        }
    }
}
