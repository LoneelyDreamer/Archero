using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class CollectedOnNearToTargetSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<Entity> _target;
        private Transform _transform;
        private ReactiveVeriable<bool> _isCollected;

        public void OnInit(Entity entity)
        {
            _target = entity.CurrentTarget;
            _transform = entity.Transform;
            _isCollected = entity.IsCollected;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isCollected.Value == false &&  _target.Value != null) 
                if((_target.Value.Transform.position - _transform.position).magnitude < 0.3f)
                    _isCollected.Value = true;
        }
    }
}
