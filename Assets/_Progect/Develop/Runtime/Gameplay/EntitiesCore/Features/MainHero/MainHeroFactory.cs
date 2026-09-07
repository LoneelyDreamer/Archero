using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero
{
    public class MainHeroFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly ConfigsProviderServise _configProvidersServise;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public MainHeroFactory(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _configProvidersServise = _container.Resolve<ConfigsProviderServise>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public Entity Create(Vector3 position)
        {
            HeroConfig config = _configProvidersServise.GetConfig<HeroConfig>();

            Entity entity = _entitiesFactory.CreateHero(position, config);

            entity
                .AddIsMainHero()
                .AddTeam(new ReactiveVeriable<Teams>(Teams.MainHero));


            entity.AddCurrentTarget();

            _brainsFactory.CreateMainHeroBrain(entity, new NearestDamageableTargetSelector(entity));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateMainHeroBilding(Vector3 position)
        {
            BildingHeroConfig config = _configProvidersServise.GetConfig<BildingHeroConfig>();

            Entity entity = _entitiesFactory.CreateBildingHero(position, config);

            entity
                .AddIsMainHero()
                .AddTeam(new ReactiveVeriable<Teams>(Teams.MainHero));
                      

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}
