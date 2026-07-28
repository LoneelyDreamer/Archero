using Assets._Progect.Develop.Runtime.Gameplay.Cupcha;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
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

        }

        private static MainMenuUIRoot CreateGamplayUIRoot(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            MainMenuUIRoot gameplayUIRootPrefab = resourcesAssetsLoader.
               Load<MainMenuUIRoot>("UI/Gameplay/GamePlayUIRoot");

            return Object.Instantiate(gameplayUIRootPrefab);
        }

    }
}
