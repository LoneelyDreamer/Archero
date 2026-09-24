using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.Gameplay.ResultsPopup;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresentorFactory
    {
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _gameplayInputArgs;

        public GameplayPresentorFactory(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public WinPopupPresentor CreateWinPopupPresentor(WinPopupView view)
        {
            return new WinPopupPresentor(view,
                _container.Resolve<SceneSwitherService>(),
                _container.Resolve<ICoroutinesPerformer>());
        }

        public DefeatPopupPresentor CreateDefeatPopupPresentor(DefeatPopupView view)
        {
            return new DefeatPopupPresentor(
                view,
                 _container.Resolve<SceneSwitherService>(),
                  _container.Resolve<ICoroutinesPerformer>(),
                  _gameplayInputArgs);
        }


        public GameplayScreenPresentor CreateGameplayScreenPresentor(GameplayScreenView view)
        {
            return new GameplayScreenPresentor(view, _container.Resolve<ProjectPresentorFactory>());
        }
    }
}
