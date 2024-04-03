using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace MonopolyGame
{
    
    internal class main
    {
        [STAThread]

        static public void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var ui = new WindowsFormsApp1.GUI();
            Application.Run(ui);

            
        }

        public void GoTo(int x)
        {
            var ui = new WindowsFormsApp1.GUI();
            ui.GoTo();
        }



        const int WIDTH = 155;
        const int HEIGHT = 55;
        const int DICE = 10;
        const int COUNT_COORD = 40;
        const int PROPERTY_POSITION = 40;
        static string map =
        "#########################################################################################################################################################\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#########################################################################################################################################################\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "###############                                                                                                                           ###############\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "###############                                                                                                                           ###############\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "###############                                                                                                                           ###############\n" +
        "#             #                                                                                                                           #             #\n" +
            "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "###############                                                                                                                           ###############\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "###############                                                                                                                           ###############\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "###############                                                                                                                           ###############\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#             #                                                                                                                           #             #\n" +
        "#########################################################################################################################################################\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#             #             #             #             #             #             #            #             #             #            #             #\n" +
        "#########################################################################################################################################################\n";

        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleCursorPosition(IntPtr hConsoleOutput, COORD dwCursorPosition);

        const int STD_OUTPUT_HANDLE = -11;

        [StructLayout(LayoutKind.Sequential)]
        struct COORD
        {
            public short X;
            public short Y;

            public COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        static void GotoXY(short x, short y)
        {
            COORD pos = new COORD(x, y);
            SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);
        }

        static Random random = new Random();

        static int RandomDice()
        {
            return random.Next(1, 7);
        }

        static int RandomStart()
        {
            return random.Next(1, 3);
        }

        static int ThrowADiceOne()
        {
            return RandomDice();
        }

        static int ThrowADiceTwo()
        {
            return RandomDice();
        }
    }
}