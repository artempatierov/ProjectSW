using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        public static void BuyProperty(int userId,int cellId,int cena)
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
            int licznik_wieznia = 0;
            int kosc_1= random.Next(1, 6);
            int kosc_2= random.Next(1, 6);
            if(kosc_1 == kosc_2)
            {
                Console.WriteLine("Dublet!");
                    //zamiast tej konsoli dodać okienko popup
                licznik_wieznia++;
                if (licznik_wieznia > 2)
                {
                    //Player.idziesz_do_paki_hehe();
                }
            }
            return kosc_1 + kosc_2;
        }

        public static int RandomStart(int userId)
        {
            return userId=random.Next(1, 4);
        }

        public static int NextPlayer(int userId)
        {
            userId += 1;
            if (userId > 4)
            {
                return userId = 1;
            }
            else
            {
                return userId;
            }
        }
    }
}
