using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AOE;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Energy;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Teleport;
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
                .AddIsMoving()
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
                .AddAttackProcessInitialTime(new ReactiveVeriable<float>(3))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVeriable<float>(1f))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVeriable<float>(50))
                .AddAttackCanseledEvent()
                .AddAttackCooldownInitialTime(new ReactiveVeriable<float>(2))
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
                .AddIsMoving()
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

        public Entity CreateProjectile(Vector3 position, Vector3 direction, float damage)
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
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactColliderBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVeriable<float>(damage))
                .AddDeathMask(1 << LayerMask.NameToLayer("Characters"))
                .AddIsTouchDeathMask();



            ICompositCondition canMove = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canRotate = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustDie = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value));

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
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateEmpty() => new Entity();

        public Entity CreateTeleportGhost(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesactory.Create(entity, position, "Entities/Teleported Gost");

            entity
                .AddMaxHealth(new ReactiveVeriable<float>(100))
                .AddCurrentHealth(new ReactiveVeriable<float>(100))
                .AddMaxEnergy(new ReactiveVeriable<float>(100))
                .AddCurrentEnergy(new ReactiveVeriable<float>(10))
                .AddEnergyRespawnTimeStep(new ReactiveVeriable<float>(2f))
                .AddTeleportRadius(new ReactiveVeriable<float>(3f))
                .AddTeleportSkillPrice(new ReactiveVeriable<float>(15f))
                .AddStartTeleportRequest()
                .AddStartTeleportEvent()
                .AddAOEDamage( new ReactiveVeriable<float>(70f))
                .AddAOEDamageRadius( new ReactiveVeriable<float>(10f))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVeriable<float>(2))
                .AddDeathProcessCurrentTime()
                .AddTakeDamegeRequest()
                .AddTakeDamegeEvent()                
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactColliderBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));


            ICompositCondition mustDie = new CompositCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositCondition canUseSkill = new CompositCondition()
               .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition mustSelfRealese = new CompositCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositCondition canApplyDamage = new CompositCondition()
            .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositCondition canUseTeleportSkill = new CompositCondition()
            .Add(new FuncCondition(() => entity.IsDead.Value == false))
            .Add(new FuncCondition(() => entity.CurrentEnergy.Value >= entity.TeleportSkillPrice.Value));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanUseTeleportSkill(canUseTeleportSkill)
                .AddCanApplayDamage(canApplyDamage);

            entity
                //.AddSystem(new BodyContactsDetectingSystem())
                //.AddSystem(new BodyContactEntitiesSystem(_collidersRegestryService))
                //.AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new EnergySystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new TeleportSystem())
                .AddSystem(new AOEDetectingSystem(_collidersRegestryService))
                .AddSystem(new InstantAOESystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

    }


}
