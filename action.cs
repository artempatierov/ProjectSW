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
            if (user.getInJail() == 0)
            {
                user.cellId = 10;
                user.setDoubletCount(0);
                user.setInJail();
                GoTo(user.getId(), 10);
            } else
            {
                user.increaseJail();
            }
        }

        //spr czy to pole do kogoś należy
        //jeśli tak, MessageBox z info czyje to pole
        //jeśli nie, to sprawdzić czy cena pola nie wykracza poza saldo gracza
        //jeśli wykracza to nie można kupić
        //jeśli nie to pole kupione
        public static void BuyProperty(Cell pole, Player user, Property property)
        {
            if (user.getCellId() == pole.getId() && pole.getId() == property.getPropId())//Czy gracz stoi na polu
            {
                if (property.getPlayerOwnerId() == -1)//Czy pole jest niczyje
                {
                    if (property.getPropPrice() > user.getMoney())//Czy cena pola nie jest większa niż stan konta gracza
                    {
                        MessageBox.Show("Niewystarczające środki!!!");
                    }
                    else
                    {
                        property.setPlayerOwnerId(user.getId());
                        user.removeMoney(property.getPropPrice());
                        MessageBox.Show("Pole Zakupione");
                        property.setVisible(true);
                    }
                }
                else
                {
                    if (property.getPlayerOwnerId() == user.getId())
                        MessageBox.Show("Pole należy do: " + user.getName());
                }
            }
        }

        public static void PropertySwap(Player player1, Player player2, Property property1, Property property2)
        {

        }

        static Random random = new Random();
        public static int RollDice()
        {
            int kosc_1 = random.Next(1, 6);
            int kosc_2 = random.Next(1, 6);
            if (kosc_1 == kosc_2)
            {
                Console.WriteLine("Dublet!");
                return (kosc_1 + kosc_2) * -1;
            }
            return kosc_1 + kosc_2;
        }

        public static void RollChest()
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player player = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            int los = random.Next(1, 5);
            switch (los) {
                case 1
                    : MessageBox.Show("Przejdz na pole \"Wizyta w więzieniu\"");
                    GoTo(player.getId(), 10);
                    break;
                case 2
                    :
                    MessageBox.Show("Przejdz na pole \"Start\"");
                    GoTo(player.getId(), 1);
                    break;
                case 3
                    :
                    MessageBox.Show("Otrzymujesz zwrot podatku!\n100 dolarów trafia na twoje konto!");
                    player.addMoney(100);
                    break;
                case 4
                    :
                    MessageBox.Show("Płacisz za Fryzjera!\n50 dolarów znika z twojego konta!\"");
                    player.removeMoney(50);
                    break;
                case 5
                    :
                    MessageBox.Show("Idziesz do Więzienia!\nCo za pech!");
                    GoToJail(player);
                    break;
            }
        }

        public static void RollChance()
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player player = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            int los = random.Next(1, 5);
            switch (los)
            {
                case 1
                    :
                    MessageBox.Show("Przejdz na pole \"Kolei Penn\"");
                    GoTo(player.getId(), 15);
                    break;
                case 2
                    :
                    MessageBox.Show("Przejdz na pole \"Wodociągi\"");
                    GoTo(player.getId(), 28);
                    break;
                case 3
                    :
                    MessageBox.Show("Otrzymujesz spadek po krewnym!\n1000 dolarów trafia na twoje konto!");
                    player.addMoney(1000);
                    break;
                case 4
                    :
                    MessageBox.Show("Twoje dziecko zachorowało!\n500 dolarów znika z twojego konta!\"");
                    player.removeMoney(500);
                    break;
                case 5
                    :
                    MessageBox.Show("Darmowe wyjście z Więzienia!\nCo za Szczęście!");
                    player.addFreeJailExit();
                    break;
            }
        }

        public static void NextPlayer()
        {
            var p_Manager = PlayersManager.m_playersManager;
            int index = p_Manager.getCurrentPlayerIndex();
            index++;
            p_Manager.setCurrentPlayerIndex(index % 4);
        }
        public void PrintDetails()
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player player = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var prop_Manager = PropertyManager.m_propertyManager;
            Property property = prop_Manager.findPropertyById(prop_Manager.getCurrentPropertyIndex());
            //Zamiast dodawać property i usera jako argumenty to moge ich wyciągnąc za pomocą managerów :D
            MessageBox.Show("---Właściwości Posiadłości---" +
                "\nNazwa:" + property.getPropName() +
                "\nCena podstawowa:" + property.getPropPrice() +
                "\nWłaściciel:" + player.getName() +
                "\nCena następnego ulepszenia: " + property.getPropUpgradePrice()
                );
        }
        public static bool ProcessMove()
        {
            Extensions.LoadMoney();
            int wynik = -1;
            var p_Manager = PlayersManager.m_playersManager;
            var b_Manager = BoardManager.m_boardManager;

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
            Cell cell = b_Manager.findCellById(user.cellId);
            b_Manager.checkField(cell);

            return true;
        }
    }
}
