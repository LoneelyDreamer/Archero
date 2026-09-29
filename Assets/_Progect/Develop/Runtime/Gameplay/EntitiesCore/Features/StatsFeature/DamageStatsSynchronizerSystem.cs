using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public class DamageStatsSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _damage;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _damage = entity.InstantAttackDamage;
            //_modifiedStats = entity.ModifiedStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.Damage];

            if (tempValue < 0)
                tempValue = 0;

            _damage.Value = tempValue;
        }
    }
}
