namespace TaengvsBug.Script
{
    public interface IPlayer : IAbillity
    {
        void HideBug(int defs);
        void PretendToDie(IAbillity target, int heal);
        void LvUp(int exps);
    }
}
