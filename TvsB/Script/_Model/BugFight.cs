using System;
using UnityEngine;

namespace TaengvsBug.Script
{
    class BugFight : IAbillity
    {
        public int atk { get; set; }
        public int hp { get; set; }
        public int def { get; set; }
        public int lv { get; set; }
        public int exp { get; set; }

        public BugFight(int atk,int def,int hp,int lv,int exp)
        {
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            this.lv = lv;
            this.exp = exp;
        }

        public void Attack(IAbillity target)
        {
            if (target.def > atk) Debug.Log("  !!! Block !!!  ");
            else target.hp -= (atk - target.def);
            Debug.Log("  !!! hp !!!  "+ target.hp);
        }

        public virtual void Die(IAbillity target)
        {
            if (target.hp <= 0)
            {
                System.Random rand = new System.Random();
                lv = rand.Next(1, 10);

                atk = 10 * lv;
                def = 5 * lv;
                hp = 100 * lv;

                Console.WriteLine("\nBugHP: " + hp + "  || BugDef: " + def + "  || BugAtk: " + atk + "  || BugLv: " + lv);
            }
        }
    }
}
