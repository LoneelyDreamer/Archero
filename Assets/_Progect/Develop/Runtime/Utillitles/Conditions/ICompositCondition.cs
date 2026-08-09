namespace Assets._Progect.Develop.Runtime.Utillitles.Conditions
{
    public interface ICompositCondition : ICondition
    {
        ICompositCondition Add(ICondition condition);

        ICompositCondition Remove(ICondition condition);
    }

}
