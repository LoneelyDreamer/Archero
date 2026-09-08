using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using System;
using UnityEngine;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Mines
{
    public class MinesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesFactory _entitiesFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public MinesFactory(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public Entity Create(Vector3 position, EntityConfig config)
        {
            Entity entity = null;

            switch (config)
            {
                case MineConfig mineConfig:
                    entity = _entitiesFactory.CreateMine(position, mineConfig);                
                    break;      
                    
                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config");
            }

            entity.AddTeam(new ReactiveVeriable<Teams>(Teams.Mines));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}
