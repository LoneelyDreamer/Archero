using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AbilitiesDropingFeature
{
    public class AbilityDropingService
    {
        private readonly AbilitiyConfigsContainer _abilitiyConfigsContainer;
        private readonly AbilityDropingRuleService _abilityDropingRuleService;

        public AbilityDropingService(
            AbilitiyConfigsContainer abilitiyConfigsContainer, 
            AbilityDropingRuleService abilityDropingRuleService)
        {
            _abilitiyConfigsContainer = abilitiyConfigsContainer;
            _abilityDropingRuleService = abilityDropingRuleService;
        }

        public List<AbilitiyDropOption> Drop(int count, Entity entity)
        {
            List<AbilitiyDropOption> availableAbilities = new List<AbilitiyDropOption>();

            foreach (AbilitiyConfig abilitiyConfig in _abilitiyConfigsContainer.AbilitiyConfigs)
            {
                for (int level = 1; level < abilitiyConfig.MaxLevel + 1; level++)
                {
                    if (_abilityDropingRuleService.IsAvailable(abilitiyConfig, entity, level))
                        availableAbilities.Add(new AbilitiyDropOption(abilitiyConfig, level));
                }
            }

            List<AbilitiyDropOption> selectedAbilities = new();

            for (int i = 0; i < count; i++)
            {
                AbilitiyDropOption selectedAbility = availableAbilities[UnityEngine.Random.Range(0, availableAbilities.Count)];
                selectedAbilities.Add(selectedAbility);
                availableAbilities.Remove(selectedAbility);
            }

            return selectedAbilities;
        }

    }
}
