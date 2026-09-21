using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI
{
    public class AIParallelState : ParallelState<IUpdatableState>, IUpdatableState
    {
        public AIParallelState(params IUpdatableState[] states) : base(states)
        {

        }

        public void Update(float deltaTime)
        {
            foreach (IUpdatableState state in States)
                state.Update(deltaTime);
        }
    }
}
