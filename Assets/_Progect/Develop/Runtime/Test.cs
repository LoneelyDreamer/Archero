using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime
{
    public class Test : MonoBehaviour
    {
        private ICoroutinesPerformer _coroutinesPerformer;

        private ResourcesAssetsLoader _resourcesAssetsLoader;

        private ConfigsProviderServise _configProviderServise;

        private void Awake()
        {
            _resourcesAssetsLoader = CreateResoursesAssetLoader();

            _coroutinesPerformer = CreateCoroutinePerformer();

            _configProviderServise = CreateConfigsProviderServise();

            _coroutinesPerformer.StartPerform(LoadConfigs());
        }

        private ConfigsProviderServise CreateConfigsProviderServise()
        {
            ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(_resourcesAssetsLoader);

            return new ConfigsProviderServise(resourcesConfigsLoader);
        }

        private ResourcesAssetsLoader CreateResoursesAssetLoader() => new ResourcesAssetsLoader();

        private CoroutinesPerformer CreateCoroutinePerformer()
        {
            CoroutinesPerformer coroutinesPerformerPrefab = _resourcesAssetsLoader.
               Load<CoroutinesPerformer>("Utillities/CoroutinesPerformer");

            return Instantiate(coroutinesPerformerPrefab);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TestConfig testConfig = _configProviderServise.GetConfig<TestConfig>();
                Debug.Log(testConfig.Damage);
            }
        }

        private IEnumerator LoadConfigs()
        {
            Debug.Log("StartLoadConfigs");
            yield return _configProviderServise.LoadAsync();
            Debug.Log("EndLoadConfigs");

        }
    }
}