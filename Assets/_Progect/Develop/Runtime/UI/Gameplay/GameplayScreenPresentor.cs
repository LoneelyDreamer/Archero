using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
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

        private readonly List<IPresentor> _childPresenters = new();

        public GameplayScreenPresentor(GameplayScreenView screen)
        {
            _screen = screen;
        }

        public void Initialise()
        {
            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();
        }

        public void Dispose()
        {
            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }
    }
}
