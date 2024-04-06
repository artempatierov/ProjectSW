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
            cells[4] = new Cell(); // test
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
            switch (cell.getId())
            {
                case 0:
                    return WindowsFormsApp1.GUI.UI.start;
                case 1:
                    return WindowsFormsApp1.GUI.UI.top_1;
                case 2:
                    return WindowsFormsApp1.GUI.UI.top_2;
                case 3:
                    return WindowsFormsApp1.GUI.UI.top_3;
                case 4:
                    return WindowsFormsApp1.GUI.UI.top_4;
                case 5:
                    return WindowsFormsApp1.GUI.UI.top_5;
                case 6:
                    return WindowsFormsApp1.GUI.UI.top_6;
                case 7:
                    return WindowsFormsApp1.GUI.UI.top_7;
                case 8:
                    return WindowsFormsApp1.GUI.UI.top_8;
                case 9:
                    return WindowsFormsApp1.GUI.UI.top_9;
                // TODO: add other fields
                default:
                    return null;
            }
        }
    }
}
