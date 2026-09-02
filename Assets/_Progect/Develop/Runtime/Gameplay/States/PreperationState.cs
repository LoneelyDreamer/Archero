using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class PreperationState : State, IUpdatableState
    {
        private readonly PreparationTrigerService _preparationTrigerService;

        public PreperationState(PreparationTrigerService preparationTrigerService)
        {
            _preparationTrigerService = preparationTrigerService;
        }

        public override void Enter()
        {
            base.Enter();

            Vector3 nextStageTriggerPosition = Vector3.zero + Vector3.forward * 4;
            _preparationTrigerService.Create(nextStageTriggerPosition);
        }

        public void Update(float deltaTime)
        {
            _preparationTrigerService.Update(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _preparationTrigerService.Cleanup();
        }
    }
}
