using UnityEngine;

namespace TaengvsBug.Script
{
    public class TaengFight : MonoBehaviour
    {
        public int atk;
        public int hp;
        public int def;
        public int lv;
        public int exp;

        int maxExp;

        public void Start()
        {
            maxExp = lv * 200;
        }

        public void Attack(TaengFight target)
        {
            if (def > target.atk) Debug.Log("  !!! Block !!!  ");
            else hp -= (target.atk - def);
            PlayerDie();
        }

        public void HideBug(int defs)
        {
            def += defs;
            Debug.Log("taengdef: " + def + "  || taenghp: " + hp + "  || taengAtk: " + atk);
        }

        public void PretendToDie(int hps)
        {
            hp += hps;
            Debug.Log("taenghp: " + hp);
        }

        public void LvUp(int exps)
        {
            exp += exps;

            int _lv = (int)Mathf.Floor((float)exp / maxExp);
            int _remainExp = exp - (maxExp * _lv);
            int _newMaxExp = _lv * 200;

            lv += _lv;
            exp = _remainExp;
            maxExp += _newMaxExp;

            Debug.Log("   || exp: "+ exp);
            Debug.Log("   || maxExp: " + maxExp);
            Debug.Log("   || Lv: " + lv);
        }

        public void PlayerDie()
        {
            if (hp <= 0)
            {
                Debug.Log("TaengHP: " + hp + "  || TaengDef: " + def + "  || TaengAtk: " + atk + "  || TaengLv: " + lv);
            }
        }
    }
}
