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
        public bool IsAvailable(AbilitiyConfig config, Entity entity)
        {
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
