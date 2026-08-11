using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot
{
    public class InstantShootSystem : IInitializableSystem, IDisposable
    {
        private ReactiveEvent _attckDelayEndEvent;
        private ReactiveVeriable<float> _damage;
        private Transform _shootPoint;

        private IDisposable _attackDelayEndDisposable;

      
        public void OnInit(Entity entity)
        {
            _attckDelayEndEvent = entity.AttackDelayEndEvent;
            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;

            _attackDelayEndDisposable = _attckDelayEndEvent.Subscribe(OnAttackDealayEnd);
        }

        private void OnAttackDealayEnd()
        {
            Debug.Log($"Shoot, Damage = {_damage.Value} , _shootPoint = {_shootPoint.position}");
        }

        public void Dispose()
        {
            _attackDelayEndDisposable.Dispose();
        }

    }
}
