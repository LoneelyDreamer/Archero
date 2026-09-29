using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public class MaxHealthStatsSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _maxHealth;
        private ReactiveVeriable<float> _currentHealth;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _maxHealth = entity.MaxHealth;
            _currentHealth = entity.CurrentHealth;
            _modifiedStats = entity.ModifiedStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.MaxHealth];

            float previousRatio = _currentHealth.Value / _maxHealth.Value;

            if (tempValue < 0)
                tempValue = 0;

            _maxHealth.Value = tempValue;
            _currentHealth.Value = _maxHealth.Value * previousRatio;
        }
    }
}
