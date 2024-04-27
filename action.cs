using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Action
    {
        public static void GoTo(int userId, int cellId)
        {
            Console.WriteLine("<Action:GoTo> userId: " + userId + " to position: " + cellId);
            var ui = GUI.UI;
            var p_Manager = PlayersManager.m_playersManager;
            var b_Manager = BoardManager.m_boardManager;
            Player user = p_Manager.findPlayerById(userId);
            System.Windows.Forms.PictureBox userObj = PlayersManager.playerToObject(user);
            Cell cell = b_Manager.findCellById(cellId);
            System.Windows.Forms.PictureBox cellObj = BoardManager.cellToObject(cell);
            ui.GoTo(userObj, cellObj);
        }

        public static void GoToJail(Player user)
        {
            user.cellId = 10;
            user.setDoubletCount(0);
            user.setInJail();
            GoTo(user.getId(), 10);
        }

        public static void BuyProperty(int userId, int cellId, int cena)
        {
            //spr czy to pole do kogoś należy
            //jeśli tak, to wyłączyć (wygaśić) opcję kupna
            //jeśli nie, to sprawdzić czy cena pola nie wykracza poza saldo gracza
            //jeśli wykracza to nie można kupić
            //jeśli nie to pole kupione
        }

        static Random random = new Random();
        public static int RollDice()
        {
            int kosc_1 = random.Next(1, 6);
            int kosc_2 = random.Next(1, 6);
            if(kosc_1 == kosc_2)
            {
                Console.WriteLine("Dublet!");
                return (kosc_1 + kosc_2) * -1;
            }
            return kosc_1 + kosc_2;
        }

        public static void NextPlayer()
        {
            var p_Manager = PlayersManager.m_playersManager;
            int index = p_Manager.getCurrentPlayerIndex();
            index++;
            p_Manager.setCurrentPlayerIndex(index % 4);
        }

        public static bool ProcessMove()
        {
            Extensions.LoadMoney();
            int wynik = -1;
            var p_Manager = PlayersManager.m_playersManager;

            if (p_Manager.getCurrentPlayerIndex() == -1)
            {
                p_Manager.setCurrentPlayerIndex(0);
            }

            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            if (user.getDoubletCount() == 0) { 
                NextPlayer();
                user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            }
            if (user.decreseJail())
            {
                return true;
            }

            wynik = RollDice();
            if (user.getDoubletCount() == 2)
            {
                var ui = GUI.UI;
                MessageBox.Show("3 Dublet, Go To Jail");
                GoToJail(user);
                return true;
            }
            if (wynik < 0)
            {
                user.cellId += (wynik * -1);
                user.addDoublet();
            }
            else
            {
                user.cellId += wynik;
                user.setDoubletCount(0);
            }

            if (user.cellId % 40 < user.cellId)
            {
                user.addMoney(200);
            }
            user.cellId %= 40;
            GoTo(user.getId(), user.cellId);




            return true;
        }
    }
}
