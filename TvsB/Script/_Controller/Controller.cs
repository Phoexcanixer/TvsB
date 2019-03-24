using System.Collections.Generic;
using UnityEngine;

namespace TaengvsBug.Script
{
    public class Controller : MonoBehaviour
    {
        #region Singleton 
        public static Controller instance;

        public void Awake()
        {
            if(instance == null) instance = this;
            else Destroy(this);
            DontDestroyOnLoad(this);
        }
        #endregion

        public TaengFight _taeng;

        public void Attack()
        {
            Debug.Log("ATK");
            _taeng.Attack(_taeng);
            // BugAttack();
            // Console.WriteLine("   HP Taeng: " + _taeng.hp + "   HP Bug: " + _bug.hp);
        }

        public void HideBug()
        {
            Debug.Log("DEF");
            // _taeng.HideBug(10);
            // BugAttack();
        }

        public void PretendToDie()
        {
            Debug.Log("PTD");
            // _taeng.PretendToDie(50);
            // BugAttack();
        }
    }
}
