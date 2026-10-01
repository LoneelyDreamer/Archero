using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public class AbilitiesFactory
    {
        private DIContainer _container;

        public AbilitiesFactory(DIContainer container)
        {
            _container = container;
        }

        public Ability CreateAbilityFor(Entity entity, AbilitiyConfig config)
        {
            switch (config)
            {
                case StatChangedAbilityConfig changedAbilityConfig:
                    return new StatChangedAbility(entity, changedAbilityConfig);

                default:
                    throw new ArgumentException();
            }

        }
        
    }
}
