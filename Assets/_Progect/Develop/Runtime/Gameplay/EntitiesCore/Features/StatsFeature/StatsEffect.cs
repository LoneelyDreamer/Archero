using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public class StatsEffect : IStatsEffect
    {
        private StatTypes _statType;
        private Func<float, float> _applyEffect;

        public StatsEffect(StatTypes statType, Func<float, float> applyEffect)
        {
            _statType = statType;
            _applyEffect = applyEffect;
        }

        public void ApplyTo(Dictionary<StatTypes, float> stats)
        {
            stats[_statType] = _applyEffect(stats[_statType]);
        }
    }
}
