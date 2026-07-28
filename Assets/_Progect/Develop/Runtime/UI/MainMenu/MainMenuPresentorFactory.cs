using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Shop;
using Assets._Progect.Develop.Runtime.UI.Wallet;

namespace Assets._Progect.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPresentorFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentorFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresentor CreateMainMenuScreen(MainMenuScreenView view)
        {
            return new MainMenuScreenPresentor(
                view,
                _container.Resolve<ProjectPresentorFactory>(),
                _container.Resolve<MainMenuPopupServise>(),
                _container.Resolve<ShopServise>());
        }
    }
}
