using Assets._Progect.Develop.Runtime.Gameplay.Common;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature
{
    public class RigidbodyMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<Vector3> _moveDirection;
        private ReactiveVeriable<float> _moveSpeed;
        private Rigidbody _rigidbody;
        private ReactiveVeriable<bool> _isMoving;

        private ICompositCondition _canMove;
        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _rigidbody = entity.Rigidbody;
            _canMove = entity.CanMove;
            _isMoving = entity.IsMoving;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_canMove.Evaluate() == false)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _isMoving.Value = velocity.magnitude > 0;

            _rigidbody.velocity = velocity;
        }
    }
}
