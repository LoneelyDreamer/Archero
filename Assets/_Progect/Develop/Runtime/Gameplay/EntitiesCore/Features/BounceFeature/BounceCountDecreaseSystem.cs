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
    public class BounceCountDecreaseSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<int> _bounceCount;
        private ReactiveEvent<RaycastHit> _bounceEvent;

        private IDisposable _bounceDisposable;

        public void OnInit(Entity entity)
        {
            _bounceCount = entity.BounceCount;
            _bounceEvent = entity.BounceEvent;

            _bounceDisposable = _bounceEvent.Subscribe(OnBounceEvent);
        }

        private void OnBounceEvent(RaycastHit hit)
        {
            _bounceCount.Value--;
        }

        public void OnDispose()
        {
            _bounceDisposable.Dispose();
        }
    }
}
