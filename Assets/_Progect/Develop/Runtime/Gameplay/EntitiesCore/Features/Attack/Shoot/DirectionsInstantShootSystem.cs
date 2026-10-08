using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot
{
    public class DirectionsInstantShootSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;

        private InstantShootingDirectionArgs _directions;
        private ReactiveEvent _attckDelayEndEvent;

        private Entity _entity;

        private ReactiveVeriable<float> _damage;
        private Transform _shootPoint;

        private IDisposable _attackDelayEndDisposable;

        public DirectionsInstantShootSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;

            _attckDelayEndEvent = entity.AttackDelayEndEvent;
            _directions = entity.InstantShootingDirections;

            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;

            _attackDelayEndDisposable = _attckDelayEndEvent.Subscribe(OnAttackDealayEnd);
        }

        private void OnAttackDealayEnd()
        {
            if (_entitiesFactory == null)
                throw new Exception(nameof(_entitiesFactory));

            foreach (var arg in _directions.Args)
                Shoot(arg.Angel, arg.ProjectileCount);
           
            _entitiesFactory.CreateProjectile(_shootPoint.position, _shootPoint.forward, _damage.Value, _entity);
        }

        private void Shoot(int angel, int projectileCount)
        {
            Vector3 diractionforShoot =Quaternion.Euler(new Vector3(0, angel, 0)) * _shootPoint.forward;
            Vector2 perpindcular = Vector2.Perpendicular(new Vector2(diractionforShoot.x, diractionforShoot.z)).normalized;

            float offsetBetweenProjectiles = 0.6f;

            for (int i = 0; i < projectileCount; i++)
            {
                Vector2 offset = perpindcular * (-offsetBetweenProjectiles / 2f * (projectileCount - 1) + i * offsetBetweenProjectiles);
                Vector3 position = new Vector3(_shootPoint.position.x + offset.x, _shootPoint.position.y, _shootPoint.position.z + offset.y);

                _entitiesFactory.CreateProjectile(position, diractionforShoot, _damage.Value, _entity);
            }
        }

        public void OnDispose()
        {
            _attackDelayEndDisposable.Dispose();
        }
    }
}
