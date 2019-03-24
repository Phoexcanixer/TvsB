namespace TaengvsBug.Script
{
    public interface IPlayer : IAbillity
    {
        void HideBug(int defs);
        void PretendToDie(int hps);
        void LvUp(int exps);
    }
}
