using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public class StatsEffectsApplySystem : IInitializableSystem, IDisposableSystem
    {
        private StatsEffectsList _statsEffects;
        private Dictionary<StatTypes, float> _baseStats;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _statsEffects = entity.StatsEffects;
            _baseStats = entity.BaseStats;
            _modifiedStats = entity.ModifiedStats;

            _statsEffects.Added += OnStatsEffectsAdded;
            _statsEffects.Removed += OnStatsEffectsRemoved;

            RecalculateStats();
        }

        public void OnDispose()
        {
            _statsEffects.Added -= OnStatsEffectsAdded;
            _statsEffects.Removed -= OnStatsEffectsRemoved;
        }

        private void OnStatsEffectsRemoved(IStatsEffect obj) => RecalculateStats();
        private void OnStatsEffectsAdded(IStatsEffect obj) => RecalculateStats();

        private void RecalculateStats()
        {
            foreach (StatTypes stat in _baseStats.Keys)
                _modifiedStats[stat] = _baseStats[stat];

            foreach (IStatsEffect statEffect in _statsEffects.Elements)
                statEffect.ApplyTo(_modifiedStats);
        }
    }
}