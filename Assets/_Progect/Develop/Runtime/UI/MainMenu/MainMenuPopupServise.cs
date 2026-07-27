using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPopupServise : PopupServise
    {
        private readonly MainMenuUIRoot _uiRoot;

        public MainMenuPopupServise(ViewsFactory viewsFactory,
            ProjectPresentorFactory presentorsFactory,
            MainMenuUIRoot uiRoot) : 
            base(viewsFactory, presentorsFactory)
        {
            _uiRoot = uiRoot;
        }

        protected override Transform PopuoLayer => _uiRoot.PopupsLayer;
    }
}
