using Assets._Progect.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProviderServise _configsProviderServise;
        public PlayerDataProvider(
            ISaveLoadServise saveLoadServise,
            ConfigsProviderServise configsProviderServise) : base(saveLoadServise)
        {
            _configsProviderServise = configsProviderServise;
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
                CompletedLevels = new(),
            };

        }

        private Dictionary<CurrenceTypes, int> InitWalletData()
        {
           StartWalletConfig walletConfig = _configsProviderServise.GetConfig<StartWalletConfig>();

            Dictionary<CurrenceTypes, int> walletData = new();

            foreach (CurrenceTypes currenceTypes in Enum.GetValues(typeof(CurrenceTypes)))
                walletData[currenceTypes] = walletConfig.GetValuesFor(currenceTypes);

            return walletData;
        }
    }

}
