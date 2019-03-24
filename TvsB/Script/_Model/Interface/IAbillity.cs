namespace TaengvsBug.Script
{
    interface IAbillity
    {
        int atk { get; set; }
        int hp { get; set; }

        void Attack(IAbillity target);
        void Die(IAbillity target);
    }
}
