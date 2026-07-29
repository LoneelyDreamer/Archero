using Assets._Progect.Develop.Runtime.Gameplay.Cupcha;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContexRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            container.RegisterAsSingle(CreateGamplayUIRoot).NonLazy();
            container.RegisterAsSingle(CreateGameplayPresentorFactory);
            container.RegisterAsSingle(CreateGameplayScreenPresentor).NonLazy();
            container.RegisterAsSingle(CreateGameplayPopupServise);

        }

        private static GameplayPopupServise CreateGameplayPopupServise(DIContainer c)
        {
            return new GameplayPopupServise(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentorFactory>(),
                c.Resolve<GameplayUIRoot>());
        }


        private static GameplayUIRoot CreateGamplayUIRoot(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            GameplayUIRoot gameplayUIRootPrefab = resourcesAssetsLoader.
               Load<GameplayUIRoot>("UI/Gameplay/GamePlayUIRoot");

            return Object.Instantiate(gameplayUIRootPrefab);
        }

        private static GameplayPresentorFactory CreateGameplayPresentorFactory(DIContainer c) 
            => new GameplayPresentorFactory(c);

        private static GameplayScreenPresentor CreateGameplayScreenPresentor(DIContainer c)
        {
            GameplayUIRoot uiRoot = c.Resolve<GameplayUIRoot>();
            GameplayScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<GameplayScreenView>(ViewIDs.GameplayScreen, uiRoot.HUDLayer);

            GameplayScreenPresentor presentor = c.Resolve<GameplayPresentorFactory>().CreateGameplayScreenPresentor(view);

            return presentor;
        }




    }
}
