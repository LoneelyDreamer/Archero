using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Energy

{
    public class EnergySystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _currentEnergy;
        private ReactiveVeriable<float> _maxEnergy;
        private ReactiveVeriable<float> _energyRespawnTimeStep;

        private float _energyRespawnTime;

        public void OnInit(Entity entity)
        {
            _currentEnergy = entity.CurrentEnergy;
            _maxEnergy = entity.MaxEnergy;
            _energyRespawnTimeStep = entity.EnergyRespawnTimeStep;

            _energyRespawnTime = _energyRespawnTimeStep.Value;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_energyRespawnTime <= 0)
            {
                _energyRespawnTime = _energyRespawnTimeStep.Value;                
 
                _currentEnergy.Value = MathF.Min(_currentEnergy.Value + (_maxEnergy.Value * 0.1f), _maxEnergy.Value);
            }

            //Debug.Log("_currentEnergy.Value =" + _currentEnergy.Value);

            _energyRespawnTime -= deltaTime;
        }
    }
}
