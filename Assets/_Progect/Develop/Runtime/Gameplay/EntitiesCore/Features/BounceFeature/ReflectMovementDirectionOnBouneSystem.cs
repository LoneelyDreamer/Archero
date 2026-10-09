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
    public class ReflectMovementDirectionOnBouneSystem : IInitializableSystem, IDisposableSystem
    {
        private Transform _transform;
        private ReactiveVeriable<Vector3> _movementDirection;
        private ReactiveEvent<RaycastHit> _bounceEvent;

        private IDisposable _bounceDisposable;
       
        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _movementDirection = entity.MoveDirection;
            _bounceEvent = entity.BounceEvent;

            _bounceDisposable = _bounceEvent.Subscribe(OnBounceEvent);
        }

        private void OnBounceEvent(RaycastHit hit)
        {
            _movementDirection.Value = Vector3.Reflect(_movementDirection.Value, hit.normal);
            _transform.position = hit.point + hit.normal * 0.1f;
        }

        public void OnDispose()
        {
            _bounceDisposable.Dispose();
        }

    }
}
