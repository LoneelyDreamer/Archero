using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Shop;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.UI.WinAndLoseCaunters;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

namespace Assets._Progect.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresentor : IPresentor
    {
        private readonly MainMenuScreenView _screen;

        private readonly ProjectPresentorFactory _projectPresentorFactory;

        private readonly MainMenuPopupServise _popupServise;

        private readonly ShopServise _shopServise;

        private readonly List<IPresentor> _childPresenters = new();

        public MainMenuScreenPresentor(
            MainMenuScreenView screen,
            ProjectPresentorFactory projectPresentorFactory,
            MainMenuPopupServise popupServise,
            ShopServise shopServise)
        {
            _screen = screen;
            _projectPresentorFactory = projectPresentorFactory;
            _popupServise = popupServise;
            _shopServise = shopServise;
        }

        public void Initialise()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;
            _screen.ResetRateButtoClicked += ResetRateButtoClicked;

            CreateWallet();
            CreateWinAndLoseCaunter();

            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();
        }     

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OnOpenLevelsMenuButtonClicked;
            _screen.ResetRateButtoClicked -= ResetRateButtoClicked;

            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresentor walletPresentor = _projectPresentorFactory.CreateWalletPresentor(_screen.WalletView);

            _childPresenters.Add(walletPresentor);
        }

        private void CreateWinAndLoseCaunter()
        {
            WinAndLoseCauntersPresentor winAndLoseCauntersPresentor = _projectPresentorFactory
                .CreateWinAndLoseCauntersPresentor(_screen.RateView);

            _childPresenters.Add(winAndLoseCauntersPresentor);
        }

        private void OnOpenLevelsMenuButtonClicked()
        {
            _popupServise.OpenLevelsMenuPopup();
        }

        private void ResetRateButtoClicked()
        {
            _shopServise.BuyCountersReset();
        }

    }
}
