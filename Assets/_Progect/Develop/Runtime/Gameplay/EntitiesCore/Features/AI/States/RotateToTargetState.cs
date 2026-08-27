using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class RotateToTargetState : State, IUpdatableState
    {
        private ReactiveVeriable<Vector3> _rotationDiraction;
        private ReactiveVeriable<EntityLifeContext> _currentTarget;
        private Transform _transform;

        public RotateToTargetState(EntityLifeContext entity)
        {
            _rotationDiraction = entity.RotationDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
           if(_currentTarget.Value != null)
                _rotationDiraction.Value =(_currentTarget.Value.Transform.position - _transform.position).normalized;
        }
    }
}
