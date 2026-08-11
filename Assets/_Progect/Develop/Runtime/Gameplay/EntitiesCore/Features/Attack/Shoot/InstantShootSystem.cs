using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot
{
    public class InstantShootSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;

        private ReactiveEvent _attckDelayEndEvent;
        private ReactiveVeriable<float> _damage;
        private Transform _shootPoint;

        private IDisposable _attackDelayEndDisposable;

        public InstantShootSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void OnInit(Entity entity)
        {
            _attckDelayEndEvent = entity.AttackDelayEndEvent;
            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;

            _attackDelayEndDisposable = _attckDelayEndEvent.Subscribe(OnAttackDealayEnd);
        }

        private void OnAttackDealayEnd()
        {
            if (_entitiesFactory == null)
                throw new Exception(nameof(_entitiesFactory));

            _entitiesFactory.CreateProjectile(_shootPoint.position, _shootPoint.forward, _damage.Value);
        }


        public void OnDispose()
        {
            _attackDelayEndDisposable.Dispose();
        }
    }
}
