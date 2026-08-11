using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack
{
    public class AttackProcessTimerSystem : IInitializableSystem, IDisposable, IUpdatableSystem
    {
        private ReactiveVeriable<float> _currentTime;

        private ReactiveVeriable<bool> _inAttackProcess;

        private ReactiveEvent _startAttackEvent;

        private IDisposable _startAttackEventDisposable;

      
        public void OnInit(Entity entity)
        {
            _currentTime = entity.AttackProcessCurrentTime;
            _inAttackProcess = entity.InAttackProcess;
            _startAttackEvent = entity.StartAttackEvent;

            _startAttackEventDisposable = _startAttackEvent.Subscribe(OnStartAttackProcess);
        }

        public void Dispose()
        {
            _startAttackEventDisposable.Dispose();
        }

        private void OnStartAttackProcess()
        {
            _currentTime.Value = 0;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            _currentTime.Value += deltaTime;            
        }
    }
}
