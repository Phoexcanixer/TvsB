using System;

namespace TaengvsBug.Script
{
    public interface IController
    {
        void Attack(int player,int target);
        void Def(int player);
        void Heal(int player, int target);
    }
}
