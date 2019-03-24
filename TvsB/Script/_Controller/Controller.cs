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
        public Dictionary<int, IPlayer> players = new Dictionary<int, IPlayer>();

        public void SetPlayer()
        {
            players.Add(1, new TaengFight(10, 5, 100, 1, 0));
            players.Add(2, new TaengFight(20, 5, 100, 1, 0));
            players.Add(3, new TaengFight(30, 5, 100, 1, 0));
            players.Add(4, new TaengFight(40, 5, 100, 1, 0));

            showUI.Invoke();
        }

        public void Attack(int player,int target)
        {
            players[player].Attack(players[target]);
            showUI.Invoke();
        }

        public void Def(int player)
        {
            players[player].HideBug(10);
            showUI.Invoke();
        }

        public void Heal(int player, int target)
        {
            players[player].PretendToDie(players[target],50);
            showUI.Invoke();
        }
    }
}
