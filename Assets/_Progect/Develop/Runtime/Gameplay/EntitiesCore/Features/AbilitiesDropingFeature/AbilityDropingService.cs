using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
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

        public List<AbilitiyConfig> Drop(int count, Entity entity)
        {
            List<AbilitiyConfig> availableAbilities = new List<AbilitiyConfig>(_abilitiyConfigsContainer
                .AbilitiyConfigs
                .Where(abilityOptions => _abilityDropingRuleService.IsAvailable(abilityOptions, entity)));

            List<AbilitiyConfig> selectedAbilities = new();

            for (int i = 0; i < count; i++)
            {
                AbilitiyConfig selectedAbility = availableAbilities[UnityEngine.Random.Range(0, availableAbilities.Count)];
                selectedAbilities.Add(selectedAbility);
                availableAbilities.Remove(selectedAbility);
            }

            return selectedAbilities;
        }

    }
}
