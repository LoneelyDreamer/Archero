using Assets._Progect.Develop.Runtime.Utillitles.Conditions;

namespace Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore
{
    public class StateTransition<TState> where TState : class, IState
    {
        public StateNode<TState> ToState { get; }
        public ICondition Condition { get; }
        public StateTransition(StateNode<TState> toState, ICondition condition)
        {
            ToState = toState;
            Condition = condition;
        }
    }
}
