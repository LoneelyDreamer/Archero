using System;

namespace Assets._Progect.Develop.Runtime.Utillitles.Conditions
{
    public interface ICompositCondition : ICondition
    {
        ICompositCondition Add(ICondition condition, int order = 0, Func<bool, bool, bool> logicOperation = null);

        ICompositCondition Remove(ICondition condition);
    }

}
