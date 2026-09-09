using Assets._Progect.Develop.Runtime.Configs.Meta.ShopPrises;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Meta.Feathers.Shop
{
    public class ShopServise
    {
        private WalletServise _walletServise;
        private WinAndLoseCauntersServise _winAndLoseCauntersServise;
        private ShopPricesConfig _shopPricesConfig;
        private PlayerDataProvider _playerDataProvider;
        private ICoroutinesPerformer _coroutinesPerformer;

        public ShopServise(WalletServise walletServise,
            WinAndLoseCauntersServise winAndLoseCauntersServise, 
            ShopPricesConfig shopPricesConfig, 
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _walletServise = walletServise;
            _winAndLoseCauntersServise = winAndLoseCauntersServise;
            _shopPricesConfig = shopPricesConfig;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void BuyCountersReset()
        {
            if (_walletServise.Enough(CurrenceTypes.Gold, _shopPricesConfig.ResetPrice))
            {
                _walletServise.Spend(CurrenceTypes.Gold, _shopPricesConfig.ResetPrice);
                _winAndLoseCauntersServise.ResetCaunters();
                _coroutinesPerformer.StartPerform(_playerDataProvider.Save());

                Debug.Log("Reset");
            }
            else
            {
                Debug.Log("not Enough money");
            }
        }
    }
}
