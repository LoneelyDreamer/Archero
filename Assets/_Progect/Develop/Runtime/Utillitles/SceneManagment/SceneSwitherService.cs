using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.LoadingScreen;
using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Progect.Develop.Runtime.Utillitles.SceneManagment
{
    public class SceneSwitherService
    {
        private readonly SceneLoaderServise _sceneLoaderServise;
        private readonly ILoadingScreen _loadingScreen;
        private readonly DIContainer _projectContainer;

        private DIContainer _currentSceneContainer;

        public SceneSwitherService(SceneLoaderServise sceneLoaderServise,
            ILoadingScreen loadingScreen,
            DIContainer projectContainer)
        {
            _sceneLoaderServise = sceneLoaderServise;
            _loadingScreen = loadingScreen;
            _projectContainer = projectContainer;
        }

        public IEnumerator ProssesSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null, IInputSceneArgs mode = null)
        {
            _loadingScreen.Show();

            _currentSceneContainer?.Dispose();

            yield return _sceneLoaderServise.LoadAsync(Scenes.Empty);
            yield return _sceneLoaderServise.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindObjectOfType<SceneBootstrap>();

            if (sceneBootstrap == null)
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            _currentSceneContainer = new DIContainer(_projectContainer);

            sceneBootstrap.ProcessRegisration(sceneContainer,sceneArgs, mode);
            sceneBootstrap.Initialize();

            yield return sceneBootstrap.Initialize();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}
