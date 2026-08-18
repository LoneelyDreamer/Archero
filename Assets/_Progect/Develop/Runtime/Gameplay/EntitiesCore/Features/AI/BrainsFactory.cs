using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainContex _brainContex;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainContex = _container.Resolve<AIBrainContex>();
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
    }
}
