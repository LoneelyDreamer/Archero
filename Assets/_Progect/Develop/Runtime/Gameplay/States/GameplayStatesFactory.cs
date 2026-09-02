using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature;
using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.LevelsProgression;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class GameplayStatesFactory
    {
        private readonly DIContainer _container;

        public GameplayStatesFactory(DIContainer container)
        {
            _container = container;
        }

        public PreperationState CreatePreperationState()
        {
            return new PreperationState(_container.Resolve<PreparationTrigerService>());
        }

        public StageProcessState CreateStageProcessState()
        {
            return new StageProcessState(_container.Resolve<StageProviderService>());
        }

        public WinState CreateWinState(GameplayInputArgs gameplayInputArgs)
        {
            return new WinState(
                 _container.Resolve<IInputService>(),
                 _container.Resolve<LevelsProgressionServise>(),
                 gameplayInputArgs,
                 _container.Resolve<PlayerDataProvider>(),
                 _container.Resolve<SceneSwitherService>(),
                 _container.Resolve<ICoroutinesPerformer>());
        }

        public DefeatState CreateDefeatState()
        {
            return new DefeatState(
                 _container.Resolve<IInputService>(),
                 _container.Resolve<SceneSwitherService>(),
                 _container.Resolve<ICoroutinesPerformer>());
        }

        public GameplayStateMashine CreateCoreLoopState()
        {
            PreparationTrigerService preparationTrigerService = _container.Resolve<PreparationTrigerService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            PreperationState preperationState = CreatePreperationState();
            StageProcessState stageProcessState = CreateStageProcessState();

            ICompositCondition preparationTostageProcessCondition = new CompositCondition()
                .Add(new FuncCondition(() => preparationTrigerService.HasMainHeroContact.Value))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage()));

            FuncCondition stageProcessToPreperationCondition =
                new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResult.Completed);

            GameplayStateMashine coreLoopState = new GameplayStateMashine();

            coreLoopState.AddState(preperationState);
            coreLoopState.AddState(stageProcessState);

            coreLoopState.AddTransition(preperationState, stageProcessState, preparationTostageProcessCondition);
            coreLoopState.AddTransition(stageProcessState, preperationState, stageProcessToPreperationCondition);


            return coreLoopState;
        }
    }
}
