using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;

namespace Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore
{
    public abstract class State : IState
    {
        private ReactiveEvent _entered = new();
        private ReactiveEvent _exited = new();

        public IReadOnlyEvent Entered => _entered;

        public IReadOnlyEvent Exited => _exited;

        public virtual void Enter() => _entered.Invoke();

        public virtual void Exit() => _exited.Invoke();
        
    }
}
