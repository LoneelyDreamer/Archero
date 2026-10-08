using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AbilitiesDropingFeature
{
    public class AbilityDropingRuleService
    {
        public bool IsAvailable(AbilitiyConfig config, Entity entity, int abilityLevel)
        {
            if(config.IsUpgradable())
            {
                if(entity.Abilities.Elements.Any(ability =>
                ability.ID == config.ID 
                && ability.CurrentLevel.Value + abilityLevel > ability.MaxLevel))
                {
                    return false;
                }
            }

            switch (config)
            {
                case StatChangedAbilityConfig statChangedAbilityConfig:
                    return entity.TryGetModifiedStats(out var modifiedStats)
                        && modifiedStats.ContainsKey(statChangedAbilityConfig.StatType);
            }

            return true;
        }
    }
}
