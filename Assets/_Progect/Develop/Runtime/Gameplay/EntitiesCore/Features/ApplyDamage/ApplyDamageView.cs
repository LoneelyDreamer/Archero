using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage
{
    public class ApplyDamageView : EntityView
    {   

        [SerializeField] private ParticleSystem _applyDamageEffectPrefab;
        [SerializeField] private Transform _effectSpawnPoint;

        private ReactiveEvent<float> _damageEvent;

        private IDisposable _damageEventDisposable;
                

        protected override void OnEntityStartedWork(Entity entity)
        {
            _damageEvent = entity.TakeDamegeEvent;

            _damageEventDisposable = _damageEvent.Subscribe(OnDamaged);           
        }

        private void OnDamaged(float obj)
        {
            Instantiate(_applyDamageEffectPrefab, _effectSpawnPoint.position, Quaternion.identity);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _damageEventDisposable.Dispose();
        }
    }
}
