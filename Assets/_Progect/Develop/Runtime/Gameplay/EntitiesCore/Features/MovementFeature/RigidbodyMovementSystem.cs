using Assets._Progect.Develop.Runtime.Gameplay.Common;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature
{
    public class RigidbodyMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<Vector3> _moveDirection;
        private ReactiveVeriable<float> _moveSpeed;
        private Rigidbody _rigidbody;

        private ReactiveVeriable<bool> _isDead;
        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _rigidbody = entity.Rigidbody;
            _isDead = entity.IsDead;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isDead.Value)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _rigidbody.velocity = velocity;
        }
    }
}
