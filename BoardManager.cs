using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class BoardManager
    {
        public double g_Tax = 200.0;
        public static BoardManager m_boardManager { get; private set; }
        public static Cell[] cells = new Cell[40];
        public BoardManager()
        {
            //fill cells
            m_boardManager = this;
            for (int i = 0; i < 40; i++)
            {
                cells[i] = new Cell(i);
            }
        }

        public void fillPropertyInfo()
        {
            var pr_Manager = PropertyManager.m_PropertyManager;
            for (int i = 0; i < 40; i++)
            {
                if (findCellById(i).getCellType() == Cell.fieldType.Property)
                cells[i].setPropertyInfo(pr_Manager.findPropertyById(i));
            }
        }

        public Cell findCellById(int cellId)
        {
            Console.WriteLine("findCellById: " + cellId);
            return cells[cellId];
        }

        public static System.Windows.Forms.PictureBox cellToObject(Cell cell)
        {
            return cell.getField();
        }

        public void checkField(Cell cell)
        {
            int cellId = cell.getId();
            var p_Manager = PlayersManager.m_playersManager;
            int currentUserIndex = p_Manager.getCurrentPlayerIndex();
            Player player = p_Manager.findPlayerById (currentUserIndex);

            if (cell.getCellType() == Cell.fieldType.Tax)
            {
                player.removeMoney(g_Tax);
            }
            else if (cell.getCellType() == Cell.fieldType.Chance)
            {
                // show chance
            }
            else if (cell.getCellType() == Cell.fieldType.Chest)
            {
                // show Chest
            }




            if (cellId == 30)
            {
                MessageBox.Show("Go To Jail");
                Action.GoToJail(player);
            }
        }
    }
}
