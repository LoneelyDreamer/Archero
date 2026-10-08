using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
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

        private readonly List<IPresentor> _childPresenters = new();

        public MainMenuScreenPresentor(
            MainMenuScreenView screen,
            ProjectPresentorFactory projectPresentorFactory,
            MainMenuPopupServise popupServise)
        {
            _screen = screen;
            _projectPresentorFactory = projectPresentorFactory;
            _popupServise = popupServise;
        }

        public void Initialise()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;
            _screen.OpenUpgradeStatsButtonClicked += OnOpenUpgradeStatsButtonClicked;

            CreateWallet();


            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();
        }

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OnOpenLevelsMenuButtonClicked;
            _screen.OpenUpgradeStatsButtonClicked -= OnOpenUpgradeStatsButtonClicked;

            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresentor walletPresentor = _projectPresentorFactory.CreateWalletPresentor(_screen.WalletView);

            _childPresenters.Add(walletPresentor);
        }

        private void OnOpenLevelsMenuButtonClicked()
        {
            _popupServise.OpenLevelsMenuPopup();
        }

        private void OnOpenUpgradeStatsButtonClicked()
        {
            _popupServise.OpenStatsUpgradePopup();
        }

    }
}
