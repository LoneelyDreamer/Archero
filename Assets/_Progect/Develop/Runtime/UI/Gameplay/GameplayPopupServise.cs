using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Gameplay.ResultsPopup;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay
{
    public class GameplayPopupServise : PopupServise
    {
        private readonly GameplayUIRoot _uiRoot;
        private readonly GameplayPresentorFactory _gameplayPresentorFactory;

        public GameplayPopupServise(
            ViewsFactory viewsFactory,
            ProjectPresentorFactory presentorsFactory,
            GameplayUIRoot uiRoot,
            GameplayPresentorFactory factory = null) :
            base(viewsFactory, presentorsFactory)
        {
            _uiRoot = uiRoot;
            _gameplayPresentorFactory = factory;
        }
        protected override Transform PopuoLayer => _uiRoot.PopupsLayer;


        public WinPopupPresentor OpenWinPopup(Action closeCallback = null)
        {
            WinPopupView winPopupView = ViewsFactory.Create<WinPopupView>(ViewIDs.WinPopup, PopuoLayer);

            WinPopupPresentor popup = _gameplayPresentorFactory.CreateWinPopupPresentor(winPopupView);

            OnPopupCreated(popup, winPopupView, closeCallback);

            return popup;
        }

        public DefeatPopupPresentor OpenDefeatPopup(Action closeCallback = null)
        {
            DefeatPopupView view = ViewsFactory.Create<DefeatPopupView>(ViewIDs.DefeatPopup, PopuoLayer);

            DefeatPopupPresentor popup = _gameplayPresentorFactory.CreateDefeatPopupPresentor(view);

            OnPopupCreated(popup, view, closeCallback);

            return popup;
        }
    }
}
