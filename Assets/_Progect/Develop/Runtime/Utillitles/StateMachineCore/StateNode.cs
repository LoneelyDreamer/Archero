using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore
{
    public class StateNode<TState> where TState : class, IState
    {
        private List<StateTransition<TState>> _transitions = new();

        public StateNode(TState state)
        {
            State = state;
        }

        public TState State { get; }

        public IReadOnlyList<StateTransition<TState>> Transitions => _transitions;

        public void AddTransition(StateTransition<TState> transition) => _transitions.Add(transition);
    }


}
