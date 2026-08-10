using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContexRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея");
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreatrCollidersRegestryService);
            container.RegisterAsSingle(CreateEntitesFactory).NonLazy();
        }

        private static CollidersRegestryService CreatrCollidersRegestryService(DIContainer c)
        {
            return new CollidersRegestryService();
        }

        private static MonoEntitesFactory CreateEntitesFactory(DIContainer c)
        {
            return new MonoEntitesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<CollidersRegestryService>());
        }

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
        {
            return new EntitiesLifeContext();
        }

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
        {
            return new EntitiesFactory(c);
        }
    }
}
