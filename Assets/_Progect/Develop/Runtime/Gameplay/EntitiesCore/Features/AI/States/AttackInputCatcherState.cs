using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class AttackInputCatcherState : State, IUpdatableState
    {
        private IInputService _inputService;
        private ReactiveEvent _startAttackRequest;

        public AttackInputCatcherState(IInputService inputService, Entity entity)
        {
            _inputService = inputService;
            _startAttackRequest = entity.StartAttackRequest;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.IsAttackPressed) 
            {
                _startAttackRequest.Invoke();
            }
        }
    }
}
