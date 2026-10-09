using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public class AttackPerSecondStatsSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _attackPerSecond;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _attackPerSecond = entity.AttackPerSecond;
            _modifiedStats = entity.ModifiedStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.AttackPerSecond];

            if (tempValue < 0)
                tempValue = 0;

            _attackPerSecond.Value = tempValue;           
        }
    }
}
