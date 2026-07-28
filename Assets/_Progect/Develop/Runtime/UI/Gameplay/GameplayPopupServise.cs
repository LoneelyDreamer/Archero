using Assets._Progect.Develop.Runtime.UI.Core;
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

        public GameplayPopupServise(ViewsFactory viewsFactory,
            ProjectPresentorFactory presentorsFactory,
            GameplayUIRoot uiRoot) :
            base(viewsFactory, presentorsFactory)
        {
            _uiRoot = uiRoot;
        }

        protected override Transform PopuoLayer => _uiRoot.PopupsLayer;
    }
}
