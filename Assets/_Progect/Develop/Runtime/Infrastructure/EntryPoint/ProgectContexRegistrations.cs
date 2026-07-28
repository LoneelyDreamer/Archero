using Assets._Progect.Develop.Runtime.Configs.Meta.BonusAndPenalty;
using Assets._Progect.Develop.Runtime.Configs.Meta.ShopPrises;
using Assets._Progect.Develop.Runtime.Gameplay.BonusAndPenalty;
using Assets._Progect.Develop.Runtime.Gameplay.Cupcha;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.LevelsProgression;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataRepository;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.KeyStorage;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.Serializers;
using Assets._Progect.Develop.Runtime.Utillitles.LoadingScreen;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Progect.Develop.Runtime.Infrastructure.EntryPoint
{
    public class ProgectContexRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinePerformer);

            container.RegisterAsSingle(CreateConfigsProviderServise);

            container.RegisterAsSingle(CreateResoursesAssetLoader);

            container.RegisterAsSingle(CreateSceneLoaderService);

            container.RegisterAsSingle(CreateSceneSwitherService);

            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);

            container.RegisterAsSingle(CreateCupchaServisce);

            container.RegisterAsSingle(CreateBonusAndPenaltyServise);
            
            container.RegisterAsSingle(CreateWalletServise).NonLazy();

            container.RegisterAsSingle(CreateWinAndLoseCauntersServise).NonLazy();

            container.RegisterAsSingle(CreatePlayerDataProvider);

            container.RegisterAsSingle(CreateProgectPresentorFactory);

            container.RegisterAsSingle(CreateViewsFactory);

            container.RegisterAsSingle(CreateShopServise);

            container.RegisterAsSingle<ISaveLoadServise>(CreateSaveLoadServise);

            container.RegisterAsSingle(CreateLevelsProgressionServise).NonLazy();
        }

        private static WinAndLoseCauntersServise CreateWinAndLoseCauntersServise(DIContainer c)
        {
            Dictionary<CauntersTypes, ReactiveVeriable<int>> caunters = new();
            foreach (CauntersTypes caunterTypes in Enum.GetValues(typeof(CauntersTypes)))
                caunters[caunterTypes] = new ReactiveVeriable<int>();

            return new WinAndLoseCauntersServise(caunters, c.Resolve<PlayerDataProvider>());
        }

        private static CupchaServisce CreateCupchaServisce(DIContainer c)
        {
            ConfigsProviderServise configsProviderServise = c.Resolve<ConfigsProviderServise>();
            GameModeConfig config = configsProviderServise.GetConfig<GameModeConfig>();
            return new CupchaServisce(config);
        }

        private static ShopServise CreateShopServise(DIContainer c)
        {
            ConfigsProviderServise configsProviderServise = c.Resolve<ConfigsProviderServise>();
            ShopPricesConfig config = configsProviderServise.GetConfig<ShopPricesConfig>();
            return new ShopServise(
                c.Resolve<WalletServise>(),
                c.Resolve<WinAndLoseCauntersServise>(),
                config,
                c.Resolve<PlayerDataProvider>(),
                c.Resolve<ICoroutinesPerformer>());
        }

        private static BonusAndPenaltyServise CreateBonusAndPenaltyServise(DIContainer c)
        {
            ConfigsProviderServise configsProviderServise = c.Resolve<ConfigsProviderServise>();
            BonusAndPenaltyStartConfig config = configsProviderServise.GetConfig<BonusAndPenaltyStartConfig>();
            return new BonusAndPenaltyServise(c.Resolve<WalletServise>(), config);
        }


        public static PlayerDataProvider CreatePlayerDataProvider(DIContainer c)
        private static LevelsProgressionServise CreateLevelsProgressionServise(DIContainer c)
            => new LevelsProgressionServise(c.Resolve<PlayerDataProvider>());
       

        private static ViewsFactory CreateViewsFactory(DIContainer c)
            => new ViewsFactory(c.Resolve<ResourcesAssetsLoader>());

        private static ProjectPresentorFactory CreateProgectPresentorFactory(DIContainer c)
            => new ProjectPresentorFactory(c);
        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer c)
            =>new PlayerDataProvider(c.Resolve<ISaveLoadServise>(), c.Resolve<ConfigsProviderServise>());        

        private static SaveLoadServise CreateSaveLoadServise(DIContainer c)
        {
            IDataSerializer dataSerializer = new JsonSerializer();
            IDataKeysSorage dataKeysSorage = new MapDataKeysStarage();

            string saveFolderPath = Application.isEditor ? Application.dataPath : Application.persistentDataPath; 

            IDataRepository dataRepository = new LocalFileDataRepository(saveFolderPath, "json");

            return new SaveLoadServise(dataSerializer, dataKeysSorage, dataRepository);
        }

        private static WalletServise CreateWalletServise(DIContainer c)
        {
            Dictionary<CurrenceTypes, ReactiveVeriable<int>> currencies = new();
            foreach (CurrenceTypes currenceTypes in Enum.GetValues(typeof(CurrenceTypes)))
                currencies[currenceTypes] = new ReactiveVeriable<int>();

            return new WalletServise(currencies, c.Resolve<PlayerDataProvider>());
        }


        private static SceneLoaderServise CreateSceneLoaderService(DIContainer c)
            => new SceneLoaderServise();

        private static ConfigsProviderServise CreateConfigsProviderServise(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(resourcesAssetsLoader);

            return new ConfigsProviderServise(resourcesConfigsLoader);
        }

        private static ResourcesAssetsLoader CreateResoursesAssetLoader(DIContainer c)
            => new ResourcesAssetsLoader();

        private static SceneSwitherService CreateSceneSwitherService(DIContainer c)
        => new SceneSwitherService(
            c.Resolve<SceneLoaderServise>(),
            c.Resolve<ILoadingScreen>(),
            c);

        private static CoroutinesPerformer CreateCoroutinePerformer(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            CoroutinesPerformer coroutinesPerformerPrefab = resourcesAssetsLoader.
               Load<CoroutinesPerformer>("Utillities/CoroutinesPerformer");

            return Object.Instantiate(coroutinesPerformerPrefab);
        }

        private static StandartLoadingScreen CreateLoadingScreen(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            StandartLoadingScreen standartLoadingScreenPrefab = resourcesAssetsLoader.
               Load<StandartLoadingScreen>("Utillities/StandartLoadinfScreen");

            return Object.Instantiate(standartLoadingScreenPrefab);
        }
    }
}
