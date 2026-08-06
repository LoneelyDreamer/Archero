using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _rotationSpeed;
        private Rigidbody _rigidbody;
        public void OnInit(Entity entity)
        {
            _rotationSpeed = entity.RotationSpeed;
            _rigidbody = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 velocity = _rigidbody.velocity;

            if (velocity.magnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
                Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, _rotationSpeed.Value * deltaTime);
                _rigidbody.MoveRotation(newRotation);
            }
        }
    }
}
