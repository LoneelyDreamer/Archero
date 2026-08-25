using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.Timer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainContex _brainContex;
        private readonly IInputService _inputService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainContex = _container.Resolve<AIBrainContex>();
            _inputService = _container.Resolve<IInputService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public StateMashineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMashine combastState = CreateAutoAttackStateMashine(entity);
            PlayerInputMovmentState movementState = new PlayerInputMovmentState(entity, _inputService);
            ReactiveVeriable<Entity> currentTurget = entity.CurrentTarget;

            ICompositCondition fromMovmentToCombatStateCondition = new CompositCondition()
                .Add(new FuncCondition(() => currentTurget.Value != null))
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));

            ICompositCondition fromCombatToMovmentStateCondition = new CompositCondition(LogicOperation.Or)
                .Add(new FuncCondition(() => currentTurget.Value == null))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AIStateMashine behavior = new AIStateMashine();

            behavior.AddState(movementState);
            behavior.AddState(combastState);

            behavior.AddTransition(movementState,combastState, fromMovmentToCombatStateCondition);
            behavior.AddTransition(combastState, movementState, fromCombatToMovmentStateCondition);

            FindTargetState findTargenState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIParallelState parallelState = new AIParallelState(findTargenState, behavior);

            AIStateMashine rootStateMashine = new AIStateMashine();
            rootStateMashine.AddState(parallelState);

            StateMashineBrain brain = new StateMashineBrain(rootStateMashine);

            _brainContex.SetFor(entity, brain);

            return brain;
        }

        public StateMashineBrain CreateGostBrain(Entity entity)
        {
            AIStateMashine stateMashine = CreateRundomMovmentStateMashine(entity);
            StateMashineBrain brain = new StateMashineBrain(stateMashine);

            _brainContex.SetFor(entity,brain);

            return brain;
        }

        private AIStateMashine CreateRundomMovmentStateMashine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            RandomMovmentState randomMovmentState = new RandomMovmentState(entity, 0.5f);

            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovmentState.Entered.Subscribe(movementTimer.Restart));

            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            FuncCondition movmentTimerEndedCondition = new FuncCondition(() => movementTimer.IsOveer);
            FuncCondition idleTimerEndedCondition = new FuncCondition(() => idleTimer.IsOveer);

            AIStateMashine stateMashine = new AIStateMashine(disposables);

            stateMashine.AddState(randomMovmentState);
            stateMashine.AddState(emptyState);

            stateMashine.AddTransition(randomMovmentState, emptyState, movmentTimerEndedCondition);
            stateMashine.AddTransition(emptyState, randomMovmentState, idleTimerEndedCondition);

            return stateMashine;
        }

        private AIStateMashine CreateAutoAttackStateMashine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);

            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;
            Transform transform = entity.Transform;
            ReactiveVeriable<Entity> currentTarget = entity.CurrentTarget;

            ICompositCondition fromRotateToAttackCondition = new CompositCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angleToTarget = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.Transform.position - transform.position));
                    return angleToTarget < 1f;
                }));

            ReactiveVeriable<bool> inAttackProcess = entity.InAttackProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMashine stateMashine = new AIStateMashine();

            stateMashine.AddState(rotateToTargetState);
            stateMashine.AddState(attackTriggerState);

            stateMashine.AddTransition(rotateToTargetState, attackTriggerState, fromRotateToAttackCondition);
            stateMashine.AddTransition(attackTriggerState, rotateToTargetState, fromAttackToRotateStateCondition);

            return stateMashine;
        }
    }
}
