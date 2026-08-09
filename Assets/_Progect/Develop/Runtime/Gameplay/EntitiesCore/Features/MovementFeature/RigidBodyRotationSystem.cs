using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature
{
    public class RigidBodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<Vector3> _direction;
        private ReactiveVeriable<float> _rotationSpeed;
        private Rigidbody _rigidbody;

        private ICompositCondition _canRotate;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _direction = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;
            _canRotate = entity.CanRotate;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)           
                return;            

            if (_direction.Value == Vector3.zero)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_direction.Value.normalized);

            float step = _rotationSpeed.Value * deltaTime;

            Quaternion rotation = Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step);

            _rigidbody.MoveRotation(rotation);
        }
    }
}
