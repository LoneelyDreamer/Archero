using Assets._Progect.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Progect.Develop.Runtime.Configs.Meta.BonusAndPenalty;
using Assets._Progect.Develop.Runtime.Configs.Meta.Caunter;
using Assets._Progect.Develop.Runtime.Configs.Meta.ShopPrises;
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
            { typeof(GameModeConfig),"GameMode" },           
            { typeof(StartCauntersConfig), "Configs/Meta/Caunters/StartCauntersConfig"},
            { typeof(BonusAndPenaltyStartConfig), "Configs/Meta/BonusesAndPenaltys/BonusAndPenalty"},
            { typeof(ShopPricesConfig), "Configs/Meta/ShopPrices/ShopPricesConfig"},
            { typeof(StartWalletConfig), "Configs/Meta/Wallet/StartWalletConfig"},
            { typeof(CurrencyIconConfig), "Configs/Meta/Wallet/CurrencyIconConfig"},
            { typeof(LevelsListConfig), "Configs/Gameplay/Levels/LevelsListConfig"},
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