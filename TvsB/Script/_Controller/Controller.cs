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

        IAbillity _bug = new BugFight(10, 10, 10, 10, 10);
        IPlayer _taeng = new TaengFight(50, 50, 100, 1, 0);

        public void Attack()
        {
            _taeng.Attack(_bug);
            BugAttack();
            Console.WriteLine("   HP Taeng: " + _taeng.hp + "   HP Bug: " + _bug.hp);
        }

        public void HideBug()
        {
            _taeng.HideBug(10);
            BugAttack();
        }

        public void PretendToDie()
        {
            _taeng.PretendToDie(50);
            BugAttack();
        }

        void BugAttack()
        {
            _bug.Attack(_taeng);
            _bug.Die(_bug);
        }

    }
}
