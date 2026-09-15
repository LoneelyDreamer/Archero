using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresentor : IPresentor
    {
        private readonly GameplayScreenView _screen;
        private readonly ProjectPresentorFactory _projectPresentorFactory;

        private readonly List<IPresentor> _childPresenters = new();

        public GameplayScreenPresentor(GameplayScreenView screen,
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

        private void CreateWallet()
        {
            WalletPresentor walletPresentor = _projectPresentorFactory.CreateWalletPresentor(_screen.WalletView);

            _childPresenters.Add(walletPresentor);
        }

        public void Dispose()
        {
            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }
    }
}
