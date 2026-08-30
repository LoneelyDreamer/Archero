using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
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

        public Entity CreateHero(Vector3 position, HeroConfig heroConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesactory.Create(entity, position, "Entities/Hero");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVeriable<float>(heroConfig.MoveSpeed))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVeriable<float>(heroConfig.RotationSpeed))
                .AddMaxHealth(new ReactiveVeriable<float>(heroConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVeriable<float>(heroConfig.MaxHealth))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVeriable<float>(heroConfig.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamegeRequest()
                .AddTakeDamegeEvent()
                .AddAttackProcessInitialTime(new ReactiveVeriable<float>(heroConfig.AttackProcessTime))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVeriable<float>(heroConfig.AttackDelayTime))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVeriable<float>(heroConfig.InstantAttackDamage))
                .AddAttackCanseledEvent()
                .AddAttackCooldownInitialTime(new ReactiveVeriable<float>(heroConfig.AttackColdown))
                .AddAttackCooldownCurrentTime()
                .AddInAttackCooldown();




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

            ICompositCondition canStartAttack = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.IsMoving.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));

            ICompositCondition mustCansolAttack = new CompositCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.IsMoving.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage)
                .AddCanStartAttack(canStartAttack)
                .AddMustCanselAttack(mustCansolAttack);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidBodyRotationSystem())
                .AddSystem(new AttackCanselSystem())
                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new InstantShootSystem(this))
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateGhost(Vector3 position, GostConfig gostConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesactory.Create(entity, position, "Entities/Ghost");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVeriable<float>(gostConfig.MoveSpeed))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVeriable<float>(gostConfig.RotationSpeed))
                .AddMaxHealth(new ReactiveVeriable<float>(gostConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVeriable<float>(gostConfig.MaxHealth))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVeriable<float>(gostConfig.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamegeRequest()
                .AddTakeDamegeEvent()
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactColliderBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVeriable<float>(gostConfig.BodyContactDamage));


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

            return entity;
        }

        public Entity CreateProjectile(Vector3 position, Vector3 direction, float damage, Entity owner)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesactory.Create(entity, position, "Entities/Projectile");

            entity
                .AddMoveDirection(new ReactiveVeriable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVeriable<float>(10))
                .AddIsMoving()
                .AddRotationDirection(new ReactiveVeriable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVeriable<float>(9999))
                .AddIsDead()
                .AddContactsDetectingMask(Layers.CharactersMask | Layers.EnviromentMask)
                .AddContactColliderBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVeriable<float>(damage))
                .AddDeathMask(Layers.EnviromentMask)
                .AddIsTouchDeathMask()
                .AddIsTouchAnotherTeam()
                .AddTeam(new ReactiveVeriable<Teams>(owner.Team.Value));



            ICompositCondition canMove = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value))
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));


            ICompositCondition mustSelfRealese = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidBodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactEntitiesSystem(_collidersRegestryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateContactTrigger(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesactory.Create(entity, position, "Entities/ContactTrigger");

            entity
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactColliderBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));

            entity
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactEntitiesSystem(_collidersRegestryService));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateEmpty() => new Entity();

    }
}
