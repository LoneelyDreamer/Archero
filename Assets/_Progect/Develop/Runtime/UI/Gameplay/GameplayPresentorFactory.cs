using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Shop;
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
    public class GameplayPresentorFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentorFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayScreenPresentor CreateGameplayScreenPresentor(GameplayScreenView view)
        {
            return new GameplayScreenPresentor(view);
        }
    }
}
