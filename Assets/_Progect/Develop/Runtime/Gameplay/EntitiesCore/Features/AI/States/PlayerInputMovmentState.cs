using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class PlayerInputMovmentState : State, IUpdatableState
    {
        private IInputService _inputService;
        private ReactiveVeriable<Vector3> _movementDirection;
        private ReactiveVeriable<Vector3> _rotationDirection;

        public PlayerInputMovmentState(Entity entity, IInputService inputService)
        {
            _inputService = inputService;
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

        }

        public void Update(float deltaTime)
        {
            _movementDirection.Value = _inputService.Direction;
            _rotationDirection.Value = _inputService.Direction;
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }
    }
}
