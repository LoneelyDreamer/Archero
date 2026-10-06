using Assets._Progect.Develop.Runtime.Configs.Meta.Stats;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro.EditorUtilities;
using static Assets._Progect.Develop.Runtime.Configs.Meta.Stats.PlayerStatUpgradeCostConfig;

namespace Assets._Progect.Develop.Runtime.Meta.Feathers.StatsUpgrade
{
    public class StatsUpgradeService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private ConfigsProviderServise _configsProviderServise;

        private readonly Dictionary<StatTypes, ReactiveVeriable<int>> _statsLevels = new();

        public StatsUpgradeService(
            PlayerDataProvider playerDataProvider,
            ConfigsProviderServise configsProviderServise)
        {
            _configsProviderServise = configsProviderServise;

            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public List<StatTypes> AvalableStats => _statsLevels.Keys.ToList();

        public IReadOnlyVeriable<int> GetStatLevelFor(StatTypes statTypes)
            => _statsLevels[statTypes];

        private PlayerStatUpgradeCostConfig PlayerStatsByLevelConfig => _configsProviderServise.GetConfig<PlayerStatUpgradeCostConfig>();

        public float GetCurrentStatValueFor(StatTypes type)
        {
            return PlayerStatsByLevelConfig.GetStatConfig(type).StatValues[_statsLevels[type].Value - 1];
        }

        public CurrenceTypes GetUpgradeCostTypeFor(StatTypes statTypes)
        {
            return PlayerStatsByLevelConfig.GetStatConfig(statTypes).CostType;
        }

        public bool TryGetStatValueForNextLevel(StatTypes type, out float statValue)
        {
            StatUpgradeCostConfig statData = PlayerStatsByLevelConfig.GetStatConfig(type);

            if (statData.StatValues.Count <= _statsLevels[type].Value)
            {
                statValue = 0;
                return false;
            }

            statValue = statData.StatValues[_statsLevels[type].Value];
            return true;
        }

        public bool TryGetUpgradeCostFor(StatTypes type, out CurrenceTypes costType, out int cost)
        {
            StatUpgradeCostConfig statData = PlayerStatsByLevelConfig.GetStatConfig(type);

            if (statData.UpgradeToNextLevelCost.Count <= _statsLevels[type].Value - 1)
            {
                costType = default(CurrenceTypes);
                cost = 0;
                return false;                
            }

            costType = statData.CostType;
            cost = statData.UpgradeToNextLevelCost[_statsLevels[type].Value - 1];
            return true;
        }

        public bool TryUpgradeStat(StatTypes type)
        {
            StatUpgradeCostConfig statData = PlayerStatsByLevelConfig.GetStatConfig(type);

            if(statData.StatValues.Count <= _statsLevels[type].Value)
                return false;

            _statsLevels[type].Value += 1;
            return true;
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (var statLevel in data.StatsUpgradeLevel)
            {
                if (_statsLevels.ContainsKey(statLevel.Key))
                    _statsLevels[statLevel.Key].Value = statLevel.Value;
                else
                    _statsLevels.Add(statLevel.Key, new ReactiveVeriable<int>(statLevel.Value));
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (var stat in _statsLevels)
            {
                if (data.StatsUpgradeLevel.ContainsKey(stat.Key))
                    data.StatsUpgradeLevel[stat.Key] = stat.Value.Value;
                else
                    data.StatsUpgradeLevel.Add(stat.Key, stat.Value.Value);
            }
        }
    }
}
