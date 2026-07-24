using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System.Collections.Generic;

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
            _screen.OpenTestPopupButtonClicked += OnOpenTestPopupButtonClicked;

            CreateWallet();


            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();
        }


        public void Dispose()
        {
            _screen.OpenTestPopupButtonClicked -= OnOpenTestPopupButtonClicked;

            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresentor walletPresentor = _projectPresentorFactory.CreateWalletPresentor(_screen.WalletView);

            _childPresenters.Add(walletPresentor);
        }

        private void OnOpenTestPopupButtonClicked()
        {
            _popupServise.OpenTestPopup();
        }

    }
}
