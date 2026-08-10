using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly CollidersRegestryService _collidersRegestryService;
        private readonly MonoEntitesFactory _monoEntitiesactory;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesactory = _container.Resolve<MonoEntitesFactory>();
            _collidersRegestryService = _container.Resolve<CollidersRegestryService>();
        }

        public Entity CreateHero(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesactory.Create(entity, position, "Entities/Hero");

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
                .AddDeathProcessCurrentTime()
                .AddTakeDamegeRequest()
                .AddTakeDamegeEvent();


            ICompositCondition canMove = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositCondition mustSelfRealese = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositCondition canApplyDamage = new CompositCondition()
            .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidBodyRotationSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
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
                .AddDeathProcessCurrentTime()
                .AddTakeDamegeRequest()
                .AddTakeDamegeEvent()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactColliderBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVeriable<float>(50));


            ICompositCondition canMove = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositCondition mustSelfRealese = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositCondition canApplyDamage = new CompositCondition()
            .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidBodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactEntitiesSystem(_collidersRegestryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateEmpty() => new Entity();

    }
}
