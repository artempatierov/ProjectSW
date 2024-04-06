using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //var ui = WindowsFormsApp1.GUI.UI;
            Console.WriteLine("findCellById: " + cellId);
            return cells[cellId];
        }

        public static System.Windows.Forms.PictureBox cellToObject(Cell cell)
        {
            //var ui = WindowsFormsApp1.GUI.UI;
            return Extensions.GetElementByTabIndex(cell.getId());
        }
    }
}
