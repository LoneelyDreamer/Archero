using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore
{
    public class StateNode<TState> where TState : class, IState
    {
        public StateNode(TState state)
        {
            State = state;
        }

        public TState State { get; }
    }
}
