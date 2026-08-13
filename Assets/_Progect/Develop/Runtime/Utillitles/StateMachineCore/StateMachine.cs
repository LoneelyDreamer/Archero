using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore
{
    public abstract class StateMachine<TState> where TState : class, IState
    {
        private List<StateNode<TState>> _states = new();

        private StateNode<TState> _currentState;

        private bool _isRunning;

        protected TState CurrentState => _currentState.State;

        public void AddState(TState state) => _states.Add(new StateNode<TState>(state));

        public void AddTransition(TState fromState, TState toState, ICondition condition)
        {
            StateNode<TState> from = _states.First(stateNode => stateNode.State == fromState);
            StateNode<TState> to = _states.First(stateNode => stateNode.State == toState);

            from.AddTransition(new StateTransition<TState>(to, condition));
        }
    }



}
