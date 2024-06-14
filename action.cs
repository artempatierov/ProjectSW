using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Action
    {
        public Action()
        {
            setPlayersStartPosition();
        }
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
            if (cellId != 10)
            {
                ifStartCrossed(userId, cellId);
            }
            user.setCellId(cellId);
            ui.GoToGui(userObj, cellObj);
        }

        public static void AddToPosition(int userId, int value)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(userId);

            int currentCellId = user.getCellId();
            int newCellId = currentCellId + value;
            newCellId %= 40;

            GoTo(userId, newCellId);
        }

        public static bool IfCrossed(int userId, int cellId)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(userId);

            return user.getCellId() > cellId;
        }

        public static void ifStartCrossed(int userId, int celId)
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(userId);
            if (IfCrossed(userId, celId))
            {
                Console.WriteLine("<Action:ifStartCrossed> userId: " + userId + " crossed the start ");
                user.addMoney(200);
            }
        }

        public static void GoToJail(Player user)
        {
            user.setDoubletCount(0);
            user.setInJail();
            GoTo(user.getId(), 10);
        }

        public static void setPlayersStartPosition()
        {
            var p_Manager = PlayersManager.m_playersManager;

            for (int i = 0; i < 4; i++)
            {
                p_Manager.setCurrentPlayerIndex(i);
                GoTo(i, 0);
            }
            p_Manager.setCurrentPlayerIndex(0);
        }

        //spr czy to pole do kogoś należy
        //jeśli tak, MessageBox z info czyje to pole
        //jeśli nie, to sprawdzić czy cena pola nie wykracza poza saldo gracza
        //jeśli wykracza to nie można kupić
        //jeśli nie to pole kupione
        public static void BuyProperty()
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            Console.WriteLine("<Action:BuyProperty> userId: " + user.getId() + " cellId: " + user.getCellId());

            if (property != null)
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
                        property.setVisible(true);//Do przerobienia
                    }
                }
                else
                {
                    MessageBox.Show("Pole należy do: " + user.getName());
                }
            }
            else
            {
                MessageBox.Show("Tego pola nie da się kupić!");
            }

        }

        public static void PayRent()
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player current_user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());

            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(current_user.getCellId());

            Property property = pole.getPropertyInfo();
            Player owner_user = p_Manager.findPlayerById(property.getPlayerOwnerId());

            if (property.getPlayerOwnerId() != -1)
            {
                string info = "Opłata dla " + owner_user.getName() + " za postój wynosi:\n" + property.getRentPrice();
                MessageBox.Show(info, "", MessageBoxButtons.OK);
                current_user.removeMoney(property.getRentPrice());
                owner_user.addMoney(property.getRentPrice());
            }
        }

        /*        public static void PropertySwap()
                {
                    var p_Manager = PlayersManager.m_playersManager;
                    Player user1 = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
                    var b_Manager = BoardManager.m_boardManager;
                    Cell pole1 = b_Manager.findCellById(user1.getCellId());


                }*/

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
            MessageBox.Show("Wylosuj Kartę!", "", MessageBoxButtons.OK);
            var p_Manager = PlayersManager.m_playersManager;
            Player player = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            int los = random.Next(1, 5);
            switch (los)
            {
                case 1
                    :
                    MessageBox.Show("Przejdz na pole \"Wizyta w więzieniu\"");
                    GoTo(player.getId(), 10);
                    break;
                case 2
                    :
                    MessageBox.Show("Przejdz na pole \"Start\"");
                    GoTo(player.getId(), 0);
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
            MessageBox.Show("Wylosuj Kartę!", "", MessageBoxButtons.OK);
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
                    if (player.getInJail() <= 0)
                    {
                        player.addFreeJailExit();
                    }
                    break;
            }
        }

        public static void auction(Cell cell)
        {
            var p_Manager = PlayersManager.m_playersManager;
            int currentActualPlayer = p_Manager.getCurrentPlayerIndex();
            int currentPlayer = p_Manager.getCurrentPlayerIndex();
            Property property = cell.getPropertyInfo();
            double currentPrice = 0.0;

            //Player[] players = p_Manager.GetPlayers();
            bool[] activePlayers = new bool[4] {true, true, true, true};
            int activePlayersCount = 4;

            while (true)
            {
                for (int i = 0; i < activePlayersCount; i++)
                {
                    Player user = p_Manager.findPlayerById(currentPlayer);

                    string caption = "Licytacja za " + property.getPropName();
                    string info = "Your Turn " + user.getName() + "\n\nCena pierwotna: " + property.getPropPrice() + "\n Cena aktualna: " + currentPrice + "\n\n Wciśnij 'Tak' jeżeli chcesz podbić cenę o 50 $ \n Wciśnij 'Nie' jak chcesz wyjść z licytacji";

                    if (activePlayersCount == 1)
                    {
                        if(currentPrice == 0)
                        {
                            MessageBox.Show("Ale pole śmierdzi nikt go nie chce :/", caption);
                            p_Manager.setCurrentPlayerIndex(currentActualPlayer);
                            return;
                        }
                        caption = "Licytacja za " + property.getPropName();
                        if (user.getMoney() >= currentPrice)
                        {
                            MessageBox.Show("Wygrałeś " + user.getName() + "!!!\n\nCena pierwotna: " + property.getPropPrice() + "\n Cena aktualna: " + currentPrice, caption);
                            property.setPlayerOwnerId(user.getId());
                            user.removeMoney(currentPrice);
                        } else
                        {
                            MessageBox.Show("Koniec licytacji, nikt nie wygrał :/", caption);
                        }
                        p_Manager.setCurrentPlayerIndex(currentActualPlayer);
                        return;
                    }


                    if (MessageBox.Show(info, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (user.getMoney() > currentPrice)
                        {
                            currentPrice += 50;
                        } else
                        {
                            MessageBox.Show("Nie masz tyle siana stary XD Elo");
                            activePlayersCount--;
                            activePlayers[currentPlayer] = false;
                        }
                    }
                    else
                    {
                        activePlayersCount--;
                        activePlayers[currentPlayer] = false;
                    }

                    if(activePlayersCount == 0)
                    {
                        p_Manager.setCurrentPlayerIndex(currentActualPlayer);
                        return;
                    }

                    while (true)
                    {
                        currentPlayer++;
                        currentPlayer %= 4;
                        if (activePlayers[currentPlayer] == true)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public static void NextPlayer()
        {
            var p_Manager = PlayersManager.m_playersManager;
            var b_Manager = BoardManager.m_boardManager;
            int index = p_Manager.getCurrentPlayerIndex();
            index++;
            p_Manager.setCurrentPlayerIndex(index % 4);
            b_Manager.ShowPlayersProperties(p_Manager.getCurrentPlayerIndex());
        }
        public static void PrintDetails()
        {
            var p_Manager = PlayersManager.m_playersManager;
            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            var b_Manager = BoardManager.m_boardManager;
            Cell pole = b_Manager.findCellById(user.getCellId());
            Property property = pole.getPropertyInfo();
            if (property != null)
            {
                string owner;
                if (property.getPlayerOwnerId() != -1)
                {
                    owner = user.getName();
                }
                else
                {
                    owner = "Pole niczyje";
                }
                MessageBox.Show("----Właściwości Posiadłości----" +
                    "\n\nNazwa: " + property.getPropName() +
                    "\n\nCena podstawowa: " + property.getPropPrice() +
                    "\n\nWłaściciel: " + owner +
                    "\n\nCena następnego ulepszenia: " + property.getPropUpgradePrice()
                    );
            }
        }
        public static bool ProcessMove()
        {
            Extensions.LoadMoney();
            var p_Manager = PlayersManager.m_playersManager;
            var b_Manager = BoardManager.m_boardManager;

            Player user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            if (user.getDoubletCount() == 0)
            {
                NextPlayer();
                user = p_Manager.findPlayerById(p_Manager.getCurrentPlayerIndex());
            }
            if (user.decreseJail())
            {
                return true;
            }

            int wynik = RollDice();
            if (user.getDoubletCount() == 2)
            {
                MessageBox.Show("3 Dublet, Go To Jail");
                GoToJail(user);
                return true;
            }
            if (wynik < 0)
            {
                wynik *= -1;
                user.addDoublet();
            }
            else
            {
                user.setDoubletCount(0);
            }

            AddToPosition(user.getId(), wynik);
            Cell cell = b_Manager.findCellById(user.getCellId());
            b_Manager.checkField(cell);

            return true;
        }
    }
}
