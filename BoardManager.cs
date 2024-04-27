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

            if (cellId == 30)
            {
                MessageBox.Show("Go To Jail");
                Action.GoToJail(player);
            }
        }
    }
}
