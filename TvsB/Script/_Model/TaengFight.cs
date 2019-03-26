using System;
using UnityEngine;

namespace TaengvsBug.Script
{
    class TaengFight : BugFight,IPlayer
    {
        public int maxExp;
        int _defaultMaxExp = 100;

        public TaengFight(int atk, int def, int hp, int lv,int exp,int reward) 
            :base (atk,def,hp,lv,exp,reward)
        {
            maxExp = lv * _defaultMaxExp;
        }

        public void HideBug(int defs)
        {
            def += defs;
            Debug.Log("taengdef: " + def + "  || taenghp: " + hp + "  || taengAtk: " + atk);
        }

        public void PretendToDie(IAbillity target,int heal)
        {
            target.hp += heal;
            Debug.Log("taenghp: " + target.hp);
        }

        public void LvUp(int exps)
        {
            exp += exps;

            while (exp >= maxExp)
            {
                exp -= maxExp;
                lv++;
                maxExp = lv * _defaultMaxExp;
            }

            Debug.Log("   || exp: "+ exp);
            Debug.Log("   || maxExp: " + maxExp);
            Debug.Log("   || Lv: " + lv);
        }

        public override void Die(IAbillity target)
        {
            if (target.hp <= 0)
            {
                Debug.Log("My Die");
                //Debug.Log("TaengHP: " + hp + "  || TaengDef: " + def + "  || TaengAtk: " + atk + "  || TaengLv: " + lv);
            }
        }
    }
}
