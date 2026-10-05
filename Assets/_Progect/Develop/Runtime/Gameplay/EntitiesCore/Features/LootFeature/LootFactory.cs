using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class LootFactory
    {
        private EntitiesFactory _entitiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;

        public LootFactory(DIContainer container)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
        }

        public Entity CreateExperienceLoot(string prefabPath, Vector3 position, float experience)
        {
            Entity pullableBase = _entitiesFactory.CreatePullable(prefabPath, position);

            pullableBase
                .AddExperience(new ReactiveVeriable<float>(experience))
                .AddSystem(new CollectExperiensToTargetSystem());

            _entitiesLifeContext.Add(pullableBase);

            return pullableBase;
        }

        public Entity CreateCoinsLoot(string prefabPath, Vector3 position, int coins)
        {
            Entity pullableBase = _entitiesFactory.CreatePullable(prefabPath, position);

            pullableBase
                .AddCoins(new ReactiveVeriable<int>(coins))
                .AddSystem(new CollectCoinsToTargetSystem());

            _entitiesLifeContext.Add(pullableBase);

            return pullableBase;
        }

        public Entity CreateHealthLoot(string prefabPath, Vector3 position, float health)
        {
            Entity pullableBase = _entitiesFactory.CreatePullable(prefabPath, position);

            pullableBase
                .AddCurrentHealth(new ReactiveVeriable<float>(health))
                .AddSystem(new CollectHealthToTargetSystem());

            _entitiesLifeContext.Add(pullableBase);

            return pullableBase;
        }
    }
}
