using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Playables;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public class AbilityOnAddActivatorSystem : IInitializableSystem, IDisposableSystem
    {
        private AbilitiesList _abilitiesList;

        public void OnInit(Entity entity)
        {
            _abilitiesList = entity.Abilities;

            _abilitiesList.Added += OnAbilityAdded;

            foreach (Ability ability in _abilitiesList.Elements)
                ability.Actvate();

        }

        private void OnAbilityAdded(Ability ability)
        {
            ability.Actvate();
        }

        public void OnDispose()
        {
            _abilitiesList.Added -= OnAbilityAdded;
        }

      
    }
}
