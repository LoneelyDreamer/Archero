using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly MonoEntitesFactory _monoEntitiesactory;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesactory = _container.Resolve<MonoEntitesFactory>();
        }

        public Entity CreateGhost(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesactory.Create(entity, position, "Entities/Ghost");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVeriable<float>(10))
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVeriable<float>(900))
                .AddMaxHealth(new ReactiveVeriable<float>(100))
                .AddCurrentHealth(new ReactiveVeriable<float>(100))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVeriable<float>(2))
                .AddDeathProcessCurrentTime();

            ICompositCondition canMove = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositCondition mustSelfRealese = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidBodyRotationSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));



            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateEmpty() => new Entity();

    }
}
