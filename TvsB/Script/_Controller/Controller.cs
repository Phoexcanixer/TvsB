using System;
using UnityEngine;

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

        IPlayer _taeng01 = new TaengFight(50, 50, 100, 1, 0);
        IPlayer _taeng02 = new TaengFight(50, 50, 100, 1, 0);
        IPlayer _taeng03 = new TaengFight(50, 50, 100, 1, 0);
        IPlayer _taeng04 = new TaengFight(50, 50, 100, 1, 0);


        public void Attack()
        {
            Debug.Log("ATK");
        }

        public void HideBug()
        {
            Debug.Log("HideBug");
        }

        public void PretendToDie()
        {
            Debug.Log("PretendToDie");
        }
    }
}
