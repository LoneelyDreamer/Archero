using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresentor : IPresentor
    {
        private readonly MainMenuScreenView _screen;
        private readonly ProjectPresentorFactory _projectPresentorFactory;
        private readonly List<IPresentor> _childPresenters = new();

        public MainMenuScreenPresentor(
            MainMenuScreenView screen,
            ProjectPresentorFactory projectPresentorFactory)
        {
            _screen = screen;
            _projectPresentorFactory = projectPresentorFactory;
        }

        public void Initialise()
        {
            CreateWallet();

            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();
        }
        public void Dispose()
        {
            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresentor walletPresentor = _projectPresentorFactory.CreateWalletPresentor(_screen.WalletView);

            _childPresenters.Add(walletPresentor);
        }

       
    }
}
