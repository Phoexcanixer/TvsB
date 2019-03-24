namespace TaengvsBug.Script
{
    public interface IAbillity
    {
        int atk { get; set; }
        int hp { get; set; }
        int def { get; set; }
        int lv { get; set; }
        int exp { get; set; }

        void Attack(IAbillity target);
        void Die(IAbillity target);
    }
}
