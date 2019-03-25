using System.Collections.Generic;
using UnityEngine;
using System;

namespace TaengvsBug.Script
{
    public class Controller : IController
    {
        #region Singleton 
        static Controller instance;

        public static Controller Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Controller();
                }

                return instance;
            }
        }
        #endregion

        public event Action showUI;
        public List<IPlayer> players = new List<IPlayer>();

        public void SetPlayer()
        {
            players.Add(new TaengFight(10, 5, 100, 1, 0));
            players.Add(new TaengFight(20, 5, 100, 1, 0));
            players.Add(new TaengFight(30, 5, 100, 1, 0));
            players.Add(new TaengFight(40, 5, 100, 1, 0));

            InvokeUI();
        }

        public void Attack(int player,int target)
        {
            players[player].Attack(players[target]);
            InvokeUI();
        }

        public void Def(int player)
        {
            players[player].HideBug(10);
            InvokeUI();
        }

        public void Heal(int player, int target)
        {
            players[player].PretendToDie(players[target],50);
            InvokeUI();
        }

        void InvokeUI()
        {
            showUI.Invoke();
        }
    }
}
