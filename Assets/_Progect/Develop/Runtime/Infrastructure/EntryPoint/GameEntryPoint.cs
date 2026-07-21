using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.LoadingScreen;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Start progect, settings setup");
            SetupAppSettings();

            Debug.Log("Process of servises registration");
            DIContainer projectContainer = new DIContainer();
            ProgectContexRegistrations.Process(projectContainer);
            projectContainer.Initialize();

            projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitherService sceneSwitherService = container.Resolve<SceneSwitherService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            loadingScreen.Show();

            Debug.Log("Начинается инициализация сервисов");

            yield return container.Resolve<ConfigsProviderServise>().LoadAsync();

            bool isPlayerDataSaveExists = false;

            yield return playerDataProvider.Exists(result => isPlayerDataSaveExists = result);

            if(isPlayerDataSaveExists)
                yield return playerDataProvider.Load();
            else
                playerDataProvider.Reset();

            yield return new WaitForSeconds(1f);

            Debug.Log("Завершается инициализация сервисов");

            loadingScreen.Hide();

            Debug.Log("Начинается переход на другую сцену");

            yield return sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu);
        }
    }
}
