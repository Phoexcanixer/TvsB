using System;
using UnityEngine;

namespace TaengvsBug.Script
{
    class TaengFight : BugFight,IPlayer
    {
        public int maxExp;

        public TaengFight(int atk, int def, int hp, int lv,int exp) 
            :base (atk,def,hp,lv,exp)
        {
            maxExp = lv * 200;
        }

        public void HideBug(int defs)
        {
            def += defs;
            Debug.Log("taengdef: " + base.def + "  || taenghp: " + hp + "  || taengAtk: " + atk);
        }

        public void PretendToDie(int hps)
        {
            hp += hps;
            Debug.Log("taenghp: " + base.hp);
        }

        public void LvUp(int exps)
        {
            exp += exps;

            int _lv = (int)Math.Floor((double)exp / maxExp);
            int _remainExp = exp - (maxExp * _lv);
            int _newMaxExp = _lv * 200;

            lv += _lv;
            exp = _remainExp;
            maxExp += _newMaxExp;

            Debug.Log("   || exp: "+ exp);
            Debug.Log("   || maxExp: " + maxExp);
            Debug.Log("   || Lv: " + lv);
        }

        public override void Die(IAbillity target)
        {
            if (target.hp <= 0)
            {
                Debug.Log("TaengHP: " + hp + "  || TaengDef: " + def + "  || TaengAtk: " + atk + "  || TaengLv: " + lv);
            }
        }
    }
}
