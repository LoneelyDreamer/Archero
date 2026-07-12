using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.LoadingScreen;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections;
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
