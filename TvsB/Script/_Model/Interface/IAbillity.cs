namespace TaengvsBug.Script
{
    public interface IAbillity
    {
        int atk { get; set; }

        void Attack(IAbillity target);
        void PlayerDie();
    }
}
