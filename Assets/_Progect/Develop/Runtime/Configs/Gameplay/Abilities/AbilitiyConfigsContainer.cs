using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/AbilitiyConfigsContainer", fileName = "AbilitiyConfigsContainer")]
    public class AbilitiyConfigsContainer : ScriptableObject
    {
        [SerializeField] private List<AbilitiyConfig> _abilitiyConfigs;

        public IReadOnlyList<AbilitiyConfig> AbilitiyConfigs => _abilitiyConfigs;

        public AbilitiyConfig GetConfigBy(string ID) => _abilitiyConfigs.First(config => config.ID == ID);
    }
}
