using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage
{
    public class ApplyDamageSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _damageRequest;
        private ReactiveEvent<float> _damageEvent;

        private ReactiveVeriable<float> _health;

        private ICompositCondition _canApplayDamage;

        private IDisposable _requestDisposable;
              

        public void OnInit(EntityLifeContext entity)
        {
            _damageRequest = entity.TakeDamegeRequest;
            _damageEvent = entity.TakeDamegeEvent;

            _health = entity.CurrentHealth;

            _canApplayDamage = entity.CanApplayDamage;

            _requestDisposable = _damageRequest.Subscribe(OnDamageRequest);
        }

        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnDamageRequest(float damage)
        {
            if(damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if(_canApplayDamage.Evaluate() == false)
                return;

            _health.Value = MathF.Max(_health.Value - damage, 0);
            _damageEvent.Invoke(damage);
            Debug.Log("I taked damege");
        }
    }
}
