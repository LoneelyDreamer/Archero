using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature
{
    public class MovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<Vector3> _moveDirection;
        private ReactiveVeriable<float> _moveSpeed;
        public void OnInit(Entity entity)
        {
            _moveDirection = entity.GetComponent<MoveDirection>().Value;
            _moveSpeed = entity.GetComponent<MoveSpeed>().Value;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            Debug.Log("Применяемая скорость " +  velocity.ToString());
        }
    }
}
