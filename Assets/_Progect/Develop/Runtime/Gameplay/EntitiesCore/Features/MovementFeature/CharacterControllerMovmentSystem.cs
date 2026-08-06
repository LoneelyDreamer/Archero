using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature
{
    public class CharacterControllerMovmentSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<Vector3> _moveDirection;
        private ReactiveVeriable<float> _moveSpeed;
        private CharacterController _characterController;
  
        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _characterController = entity.CharacterController;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _characterController.Move(velocity * deltaTime);
        }
    }
}
