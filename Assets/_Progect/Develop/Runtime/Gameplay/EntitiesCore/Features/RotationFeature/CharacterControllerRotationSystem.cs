using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.RotationFeature
{
    public class CharacterControllerRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _rotationSpeed;
        private ReactiveVeriable<Vector3> _moveDirection;
        private CharacterController _characterController;
        public void OnInit(Entity entity)
        {
            _rotationSpeed = entity.RotationSpeed;
            _characterController = entity.CharacterController;
            _moveDirection = entity.MoveDirection;
        }

        public void OnUpdate(float deltaTime)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection.Value, Vector3.up);
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, targetRotation, _rotationSpeed.Value * deltaTime);
        }
    }
}
