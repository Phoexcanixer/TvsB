using System;

namespace TaengvsBug.Script
{
    class BugFight : IAbillity
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
            if (def > target.atk) Console.WriteLine("  !!! Block !!!  ");
            else hp -= (target.atk - def);
        }

        public virtual void Die(IAbillity target)
        {
            if (target.hp <= 0)
            {
                Random rand = new Random();
                lv = rand.Next(1, 10);

                atk = 10 * lv;
                def = 5 * lv;
                hp = 100 * lv;

                Console.WriteLine("\nBugHP: " + hp + "  || BugDef: " + def + "  || BugAtk: " + atk + "  || BugLv: " + lv);
            }
        }
    }
}
