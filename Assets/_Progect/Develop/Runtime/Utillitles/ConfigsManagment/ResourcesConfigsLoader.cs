using Assets._Progect.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resources;

        private readonly Dictionary<Type, string> _configsResourcesPaths = new()
        {
            { typeof(StartWalletConfig), "Configs/Meta/Wallet/StartWalletConfig"}
        };
        public ResourcesConfigsLoader(ResourcesAssetsLoader resources)
        {
            _resources = resources;
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (KeyValuePair<Type, string> configsResourcesPath in _configsResourcesPaths)
            {
                ScriptableObject config = _resources.Load<ScriptableObject>(configsResourcesPath.Value);
                loadedConfigs.Add(configsResourcesPath.Key, config);
                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }

    }
}