using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Enemies
{
    public class EnemiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public EnemiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public EntityLifeContext Create(Vector3 position, EntityConfig config)
        {
            EntityLifeContext entity = null;

            switch(config)
            {
                case GostConfig gostConfig:
                    entity = _entitiesFactory.CreateGhost(position, gostConfig);
                    _brainsFactory.CreateGostBrain(entity);
                    break;

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config");

            }

            entity.AddTeam(new Utillitles.Reactivre.ReactiveVeriable<TeamsFactory.Teams>(Teams.Enemies));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}
