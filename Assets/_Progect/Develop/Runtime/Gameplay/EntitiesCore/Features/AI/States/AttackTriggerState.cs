using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class AttackTriggerState : State, IUpdatableState
    {
        private ReactiveEvent _attackRequest;

        public AttackTriggerState(EntityLifeContext entity)
        {
            _attackRequest = entity.StartAttackRequest;
        }

        public override void Enter()
        {
            base.Enter();

            _attackRequest.Invoke();
        }

        public void Update(float deltaTime)
        {
        }
    }
}
