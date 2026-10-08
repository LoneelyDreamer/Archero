using Assets._Progect.Develop.Runtime.Configs.Meta.Stats;
using Assets._Progect.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
using Assets._Progect.Develop.Runtime.Meta.Feathers.StatsUpgrade;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Progect.Develop.Runtime.Configs.Meta.Stats.StatsViewConfig;

namespace Assets._Progect.Develop.Runtime.UI.StatsUpgradePopup
{
    public class UpgradableStatPresentor : IPresentor
    {
        private UpgradableStatView _view;
        private StatsViewConfig _ststsViewConfig;
        private StatsUpgradeService _upgradeStatsService;
        private WalletServise _walletServise;
        private StatTypes _statType;
        private CurrencyIconConfig _currencyIconConfig;

        private List<IDisposable> _disposables = new List<IDisposable>();

        public UpgradableStatPresentor(
            UpgradableStatView view,
            StatsViewConfig ststsViewConfig,
            StatsUpgradeService upgradeStatsService, 
            WalletServise walletServise, 
            StatTypes statType,
            CurrencyIconConfig currencyIconConfig)
        {
            _view = view;
            _ststsViewConfig = ststsViewConfig;
            _upgradeStatsService = upgradeStatsService;
            _walletServise = walletServise;
            _statType = statType;
            _currencyIconConfig = currencyIconConfig;
        }

        public UpgradableStatView View => _view;

        public void Initialise()
        {
            StatViewConfig statShowData = _ststsViewConfig.GetStatViewData(_statType);

            _view.Initialize(statShowData.Name, statShowData.Sprite, GetStatValueText());

            UpdateBayButtonState();

            _view.BuyButtonView.Click += OnBuyButtonClick;

            IReadOnlyVeriable<int> statLevel = _upgradeStatsService.GetStatLevelFor(_statType);
            _disposables.Add(statLevel.Subscribe(OnStatUpgradeLevelChanged));

            IReadOnlyVeriable<int> currency = _walletServise.GetCurrence(_upgradeStatsService.GetUpgradeCostTypeFor(_statType));
            _disposables.Add(currency.Subscribe(OnWalletChanged));
        }


        public void Dispose()
        {
            _view.BuyButtonView.Click -= OnBuyButtonClick;

            foreach (var disposable in _disposables)
                disposable.Dispose();
        }

        private void OnWalletChanged(int arg1, int arg2) => UpdateBayButtonState();

        private void OnStatUpgradeLevelChanged(int arg1, int arg2) => _view.SetStatValueText(GetStatValueText());

        private void OnBuyButtonClick()
        {
            if(_upgradeStatsService.TryGetUpgradeCostFor(_statType, out CurrenceTypes currenceType, out int cost))
            {
                if (_walletServise.Enough(currenceType, cost))
                {
                    if (_upgradeStatsService.TryUpgradeStat(_statType) == false)
                        throw new Exception();

                    _walletServise.Spend(currenceType, cost);
                }
                else
                {
                    Debug.Log("Not enogh money");
                }
            }
            else
            {
                Debug.Log("Already max");
            }
               
        }

        private void UpdateBayButtonState()
        {
            if(_upgradeStatsService.TryGetUpgradeCostFor(_statType, out CurrenceTypes currenceType, out int cost))
            {
                _view.BuyButtonView.SetPriceText(cost.ToString());
                _view.BuyButtonView.ShowIcon();
                _view.BuyButtonView.SetIcon(_currencyIconConfig.GetSpriteFor(currenceType));

                if (_walletServise.Enough(currenceType, cost))
                    _view.BuyButtonView.Unlock();
                else
                    _view.BuyButtonView.Lock();
            }
            else
            {
                _view.BuyButtonView.HideIcon();
                _view.BuyButtonView.Lock();
                _view.BuyButtonView.SetPriceText("MAX");
            }
        }

        private string GetStatValueText()
        {
            float statValue = _upgradeStatsService.GetCurrentStatValueFor(_statType);
            string result = statValue.ToString();

            if(_upgradeStatsService.TryGetStatValueForNextLevel(_statType, out float nextStatValue))
            {
                result += $"<color=green>>{nextStatValue}</color>";
            }

            return result;
        }
    }
}
