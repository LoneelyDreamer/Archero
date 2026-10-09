using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Progect.Develop.Runtime.Utillitles.Conditions
{
    public class CompositCondition : ICompositCondition
    {
        private List<(ICondition, Func<bool, bool, bool>, int)> _conditions = new();
        private Func<bool, bool, bool> _standartLogicOperation;

        public CompositCondition(Func<bool, bool, bool> standartLogicOperation)
        {
            _standartLogicOperation = standartLogicOperation;
        }

        public CompositCondition() : this(LogicOperation.And)
        {
                
        }

        public ICompositCondition Add(ICondition condition, int order = 0, Func<bool, bool, bool> logicOperation = null)
        {
            _conditions.Add((condition, logicOperation, order));
            _conditions.OrderBy(cond => cond.Item3).ToList();
            return this;
        }

        //public ICompositCondition Add(ICondition condition)
        //{
        //    _conditions.Add(condition);
        //    return this;
        //}

        public bool Evaluate()
        {
            if(_conditions.Count == 0)
                return false;

            bool result = _conditions[0].Item1.Evaluate();

            for (int i = 1; i < _conditions.Count; i++)
            {
                var currentCondition = _conditions[i];

                if (currentCondition.Item2 != null)
                    result = currentCondition.Item2.Invoke(result, currentCondition.Item1.Evaluate());
                else
                    result = _standartLogicOperation.Invoke(result, currentCondition.Item1.Evaluate());               
            }

            return result;
        }

        public ICompositCondition Remove(ICondition condition)
        {
            (ICondition, Func<bool, bool, bool>, int) conditionPair = _conditions.First(condPair => condPair.Item1 == condition);
            _conditions.Remove(conditionPair);
            return this;
        }

       
    }

}
