using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.SelfDetonation
{
    public class SelfDetonationProcessTimerSystem : IInitializableSystem, IDisposableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<float> _currentTime;

        private ReactiveVeriable<bool> _inSelfDetonationProcess;

        private ReactiveEvent _startSelfDetonationEvent;

        private IDisposable _startSelfDetonationEventDisposable;


        public void OnInit(Entity entity)
        {
            _currentTime = entity.SelfDetonationProcessCurrentTime;
            _inSelfDetonationProcess = entity.InSelfDetonationProcess;
            _startSelfDetonationEvent = entity.StartSelfDetonationEvent;

            _startSelfDetonationEventDisposable = _startSelfDetonationEvent.Subscribe(OnStartSelfDetonationProcess);
        }

        private void OnStartSelfDetonationProcess()
        {
            _currentTime.Value = 0;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inSelfDetonationProcess.Value == false)
                return;

            _currentTime.Value += deltaTime;
        }

        public void OnDispose()
        {
            _startSelfDetonationEventDisposable.Dispose();
        }
    }
}
