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
        //public event Action showUI;
        public Dictionary<int,IPlayer> players = new Dictionary<int, IPlayer>();
        public List<int> countPlayer = new List<int>();

        public void SetPlayer()
        {
            players.Add(1,new TaengFight(20, 5, 100, 1, 0,400));
            players.Add(2,new TaengFight(30, 5, 100, 1, 0,50));
            players.Add(3,new TaengFight(40, 5, 100, 1, 0,50));
            players.Add(4,new TaengFight(50, 5, 100, 1, 0,50));

            foreach(var item in players)
            {
                countPlayer.Add(item.Key);
            }
            //showUI.Invoke();
        }

        public void Attack(int player,int target)
        {
            players[player].Attack(players[target]);

            if (players[target].hp <= 0)
            {
                players[player].LvUp(players[target].reward);
                players.Remove(target);
                return;
            }
            //showUI.Invoke();
        }

        public void Def(int player)
        {
            players[player].HideBug(10);
        }

        public void Heal(int player, int target)
        {
            players[player].PretendToDie(players[target],50);
        }
    }
}
