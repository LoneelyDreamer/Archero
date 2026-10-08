using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/AditionalDirectionsShootAbilityConfig", fileName = "AditionalDirectionsShootAbilityConfig")]
    public class AditionalDirectionsShootAbilityConfig : AbilitiyConfig
    {
        [SerializeField] private List<Config> _aditionalArrowsByLevel;
        public override int MaxLevel => _aditionalArrowsByLevel.Count;
        
        public List<DirectionShootConfig> GetBy(int level) => _aditionalArrowsByLevel[level - 1].DirectionShootConfigs;

        [Serializable]
        private class Config
        {
            [field: SerializeField] public List<DirectionShootConfig> DirectionShootConfigs { get; private set; }
        }
    }

    [Serializable]
    public class DirectionShootConfig
    {
        [field: SerializeField] public int Angel { get; private set; }
        [field: SerializeField] public int NumberOfProjectiles { get; private set; }
    }
}
