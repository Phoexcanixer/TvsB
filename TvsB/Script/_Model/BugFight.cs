using UnityEngine;
using System.Collections;

namespace TaengvsBug.Script
{
    public class BugFight : MonoBehaviour,IAbillity
    {
        public int atk { get; set; }
        public int hp { get; set; }

        public int def;
        public int lv;
        public int exp;

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
            if (def > target.atk) Debug.Log("  !!! Block !!!  ");
            else hp -= (target.atk - def);
        }

        public virtual void Die(IAbillity target)
        {
            if (target.hp <= 0)
            {
                lv = Random.Range(1, 10);

                atk = 10 * lv;
                def = 5 * lv;
                hp = 100 * lv;

                Debug.Log("\nBugHP: " + hp + "  || BugDef: " + def + "  || BugAtk: " + atk + "  || BugLv: " + lv);
            }
        }
    }
}
