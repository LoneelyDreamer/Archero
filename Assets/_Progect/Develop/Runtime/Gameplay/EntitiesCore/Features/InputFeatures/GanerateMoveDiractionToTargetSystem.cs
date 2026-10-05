using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures
{
    public class GanerateMoveDiractionToTargetSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<Entity> _target;
        private Transform _transform;
        private ReactiveVeriable<Vector3> _moveDirection;
        public void OnInit(Entity entity)
        {
            _target = entity.CurrentTarget;
            _transform = entity.Transform;
            _moveDirection =entity.MoveDirection;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_target.Value != null)
                _moveDirection.Value = _target.Value.Transform.position -_transform.position;
            else
                _moveDirection.Value = Vector3.zero;

        }
    }
}
