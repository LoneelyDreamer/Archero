using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.BounceFeature
{
    public class ReflectRotationDirectionOnBouneSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<Vector3> _rotationDirection;
        private ReactiveEvent<RaycastHit> _bounceEvent;

        private IDisposable _bounceDisposable;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _bounceEvent = entity.BounceEvent;

            _bounceDisposable = _bounceEvent.Subscribe(OnBounceEvent);
        }

        private void OnBounceEvent(RaycastHit hit)
        {
            _rotationDirection.Value = Vector3.Reflect(_rotationDirection.Value, hit.normal);
          
        }

        public void OnDispose()
        {
            _bounceDisposable.Dispose();
        }
    }
}
