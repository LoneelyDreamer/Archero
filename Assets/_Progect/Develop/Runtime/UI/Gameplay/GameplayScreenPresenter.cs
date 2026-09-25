using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Gameplay.Stages;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresentor
    {
        private readonly GameplayScreenView _screen;
        private readonly GameplayPresentorFactory _gameplayPresentorFactory;

        private readonly List<IPresentor> _childPresenters = new();

        public GameplayScreenPresenter(GameplayScreenView screen,         
            GameplayPresentorFactory gameplayPresentorFactory)
        {
            _screen = screen;
            _gameplayPresentorFactory = gameplayPresentorFactory;
        }

        public void Initialise()
        {
            CreateStageNumber();

            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();         
        }

        private void CreateStageNumber()
        {
            StagePresenter stagePresenter = _gameplayPresentorFactory.CreateStagePresenter(_screen.StageNumberView);

            _childPresenters.Add(stagePresenter);
        }

        public void Dispose()
        {
            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }
    }
}
