using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MonopolyGame
{
    class main
    {
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

        static void Main(string[] args)
        {
            IntPtr h = GetStdHandle(STD_OUTPUT_HANDLE);
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            bool isRunning = true;
            bool move = true;
            short takeATurn = 0;
            int diceOne = 0;
            int diceTwo = 0;
            int diceTotal = 0;
            int diceTotalComp = 0;
            int accumulator = 0;
            int accumulatorComp = 0;
            int moneyPlayer = 1500;
            int moneyComputer = 1500;
            int propertyPlayer = 0;
            int propertyComputer = 0;
            int propertyBuy = 0;
            int turn = RandomStart();
            int game;

            Console.WriteLine("                                                                                    W E L C O M E  TO  M O N O P O L Y");
            Console.WriteLine("\n\n                                                                                          Would you like to play?");
            Console.WriteLine("\n                                                                                           PRESS  [1]-Yes [0]-No ");
            game = Convert.ToInt32(Console.ReadLine());

            if (game == 0)
            {
                Console.Clear();
                GotoXY(100, 10);
                Console.WriteLine("You Exited the Game!");
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(map);
            }

            while (isRunning)
            {
                // Gameplay logic here...
            }
        }
    }
}