using System;

namespace WindowsFormsApp1
{
    internal class PlayersManager
    {
        public static PlayersManager m_playersManager { get; private set; }
        int g_CurrentPlayerIndex = -1;
        public static Player[] players = new Player[4];
        public PlayersManager()
        {
            //fill players
            m_playersManager = this;
            for (int i = 0; i < 4; i++)
            {
                players[i] = new Player(i);
            }
        }

        public void setCurrentPlayerIndex(int index)
        {
            g_CurrentPlayerIndex = index;
        }

        public int getCurrentPlayerIndex()
        {
            return g_CurrentPlayerIndex;
        }

        public Player findPlayerById(int userId)
        {
            //var ui = WindowsFormsApp1.GUI.UI;
            Console.WriteLine("findPlayerById: " + userId);
            if (players[userId] != null)
            {
                Console.WriteLine("<PlayersManager>:user with id: " + userId + " found");
                return players[userId];
            } else {
                Console.WriteLine("<PlayersManager>:user with id: " + userId + " not found");
                return null;
            }
        }

        public static System.Windows.Forms.PictureBox playerToObject(Player user)
        {
            //var ui = WindowsFormsApp1.GUI.UI;
            switch (user.getId())
            {
                case 0:
                    return WindowsFormsApp1.GUI.UI.player;
                case 1:
                    return WindowsFormsApp1.GUI.UI.bot_1;
                case 2:
                    return WindowsFormsApp1.GUI.UI.bot_2;
                case 3:
                    return WindowsFormsApp1.GUI.UI.bot_3;
                default:
                    return null;
            }
        }
    }
}
