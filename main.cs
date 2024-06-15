﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace MonopolyGame
{
    
    internal class main
    {
        static public void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var ui = new GUI();
            var pManager = new PlayersManager();
            var bManager = new BoardManager();
            var prManager = new WindowsFormsApp1.PropertyManager();
            var actions = new WindowsFormsApp1.Action();
            bManager.fillPropertyInfo();

            Application.Run(ui);
        }

        static public void GameOver()
        {
            Application.Exit();
        }

    }
}