using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class MoveToTargetState : State, IUpdatableState
    {
        private ReactiveVeriable<Vector3> _movementDirection;
        private ReactiveVeriable<Entity> _currentTarget;
        private Transform _transform;

        public MoveToTargetState(Entity entity)
        {
            _movementDirection = entity.MoveDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value != null)
                _movementDirection.Value = (_currentTarget.Value.Transform.position - _transform.position).normalized;
         
        }
    } 
}
