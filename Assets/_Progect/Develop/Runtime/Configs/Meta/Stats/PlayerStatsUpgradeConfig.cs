using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Meta.Stats
{
    [CreateAssetMenu(menuName = "Configs/Meta/PlayerStatsUpgradeConfig", fileName = "PlayerStatsUpgradeConfig")]
    public class PlayerStatUpgradeCostConfig : ScriptableObject
    {
        [SerializeField] private List<StatUpgradeCostConfig> _stats = new List<StatUpgradeCostConfig>();

        public StatUpgradeCostConfig GetStatConfig(StatTypes type)
            => _stats.First(s => s.Type == type);

        [Serializable]
        public class StatUpgradeCostConfig
        {
            [field: SerializeField] public StatTypes Type { get; private set; }
            [field: SerializeField] public List<float> StatValues { get; private set; }
            [field: SerializeField] public CurrenceTypes CostType { get; private set; } = CurrenceTypes.Gold;
            [field: SerializeField] public List<int> UpgradeToNextLevelCost { get; private set; }
        }
    }
}
