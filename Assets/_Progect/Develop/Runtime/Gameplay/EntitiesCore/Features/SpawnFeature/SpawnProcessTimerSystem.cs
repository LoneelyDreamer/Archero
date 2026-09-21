using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature
{
    public class SpawnProcessTimerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _initialTime;
        private ReactiveVeriable<float> _currentTime;

        private ReactiveVeriable<bool> _inSpawnProcess;


        public void OnInit(Entity entity)
        {
            _initialTime = entity.SpawnInitialTime;
            _currentTime = entity.SpawnCurrentTime;
            _inSpawnProcess = entity.InSpawnProcess;

            _currentTime.Value = 0;
            _inSpawnProcess.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
           if(_inSpawnProcess.Value == false)
                return;

           _currentTime.Value += deltaTime;

            if(_currentTime.Value >= _initialTime.Value) 
                _inSpawnProcess.Value = false;
        }
    }
}
