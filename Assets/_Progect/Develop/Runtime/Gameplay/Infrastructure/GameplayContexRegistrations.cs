using Assets._Progect.Develop.Runtime.Gameplay.Cupcha;
using Assets._Progect.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Enemies;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Mines;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Progect.Develop.Runtime.Gameplay.States;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContexRegistrations
    {
        private static GameplayInputArgs _inputArgs;

        public static void Process(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            container.RegisterAsSingle(CreateGamplayUIRoot).NonLazy();
            container.RegisterAsSingle(CreateGameplayPresentorFactory);
            container.RegisterAsSingle(CreateGameplayScreenPresentor).NonLazy();
            container.RegisterAsSingle(CreateGameplayPopupServise);

        }

        private static GameplayPopupServise CreateGameplayPopupServise(DIContainer c)
        {
            return new GameplayPopupServise(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentorFactory>(),
                c.Resolve<GameplayUIRoot>());
        }


        private static GameplayUIRoot CreateGamplayUIRoot(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            GameplayUIRoot gameplayUIRootPrefab = resourcesAssetsLoader.
               Load<GameplayUIRoot>("UI/Gameplay/GamePlayUIRoot");

            return Object.Instantiate(gameplayUIRootPrefab);
        }

        private static GameplayPresentorFactory CreateGameplayPresentorFactory(DIContainer c) 
            => new GameplayPresentorFactory(c);

        private static GameplayScreenPresentor CreateGameplayScreenPresentor(DIContainer c)
        {
            GameplayUIRoot uiRoot = c.Resolve<GameplayUIRoot>();
            GameplayScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<GameplayScreenView>(ViewIDs.GameplayScreen, uiRoot.HUDLayer);

            GameplayScreenPresentor presentor = c.Resolve<GameplayPresentorFactory>().CreateGameplayScreenPresentor(view);

            return presentor;
            _inputArgs = gameplayInputArgs;

            Debug.Log("Процесс регистрации сервисов на сцене геймплея");
            container.RegisterAsSingle(CreateEntitiesFactory);

            container.RegisterAsSingle(CreateEntitiesLifeContext);

            container.RegisterAsSingle(CreatrCollidersRegestryService);

            container.RegisterAsSingle(CreateBrainsFactory);

            container.RegisterAsSingle(CreateAIBrainContex);

            container.RegisterAsSingle(CreateEnemiesFactory);

            container.RegisterAsSingle(CreateMainHeroFactory);

            container.RegisterAsSingle(CreateStagesFactory);

            container.RegisterAsSingle(CreateGameplayStatesContext);

            container.RegisterAsSingle(CreateMainHeroHolderService).NonLazy();

            container.RegisterAsSingle(CreatePreparationTrigerService);

            container.RegisterAsSingle(CreateGameplayStatesFactory);

            container.RegisterAsSingle(CreateStageProviderService);

            container.RegisterAsSingle(CreateClickService);

            container.RegisterAsSingle(CreateMinesFactory);

            container.RegisterAsSingle<IInputService>(CreateDeckstopInput);

            container.RegisterAsSingle(CreateEntitesFactory).NonLazy();
        }

        private static MinesFactory CreateMinesFactory(DIContainer c)
        {
            return new MinesFactory(c);
        }

        private static ClickService CreateClickService(DIContainer c)
        {
            return new ClickService(
                c.Resolve<CollidersRegestryService>(),
                c.Resolve<MainHeroHolderService>(),
                c.Resolve<IInputService>(),
                c.Resolve<ConfigsProviderServise>(),
                c.Resolve<StageProviderService>(),
                c.Resolve<MinesFactory>());
        }

        private static GameplayStatesContext CreateGameplayStatesContext(DIContainer c)
        {
            return new GameplayStatesContext(c.Resolve<GameplayStatesFactory>().CreateGameplayStateMashine(_inputArgs));
        }

        private static GameplayStatesFactory CreateGameplayStatesFactory(DIContainer c)
        {
            return new GameplayStatesFactory(c);
        }

        private static MainHeroHolderService CreateMainHeroHolderService(DIContainer c)
        {
            return new MainHeroHolderService(c.Resolve<EntitiesLifeContext>());
        }

        private static PreparationTrigerService CreatePreparationTrigerService(DIContainer c)
        {
            return new PreparationTrigerService(
                c.Resolve<EntitiesFactory>(),
                c.Resolve<EntitiesLifeContext>());
        }

        private static StageProviderService CreateStageProviderService(DIContainer c)
        {
            return new StageProviderService(
                c.Resolve<ConfigsProviderServise>().GetConfig<LevelsListConfig>().GetBy(_inputArgs.LevalNumber),
                c.Resolve<StagesFactory>());
        }

        private static StagesFactory CreateStagesFactory(DIContainer c)
        {
            return new StagesFactory(c);
        }
        private static EnemiesFactory CreateEnemiesFactory(DIContainer c)
        {
            return new EnemiesFactory(c);
        }

        private static MainHeroFactory CreateMainHeroFactory(DIContainer c)
        {
            return new MainHeroFactory(c);
        }

        private static DeckstopInput CreateDeckstopInput(DIContainer c)
        {
            return new DeckstopInput();
        }

        private static AIBrainContex CreateAIBrainContex(DIContainer c)
        {
            return new AIBrainContex();
        }

        private static BrainsFactory CreateBrainsFactory(DIContainer c)
        {
            return new BrainsFactory(c);
        }

        private static CollidersRegestryService CreatrCollidersRegestryService(DIContainer c)
        {
            return new CollidersRegestryService();
        }

        private static MonoEntitesFactory CreateEntitesFactory(DIContainer c)
        {
            return new MonoEntitesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<CollidersRegestryService>());
        }

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
        {
            return new EntitiesLifeContext();
        }

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
        {
            return new EntitiesFactory(c);
        }




    }
}
