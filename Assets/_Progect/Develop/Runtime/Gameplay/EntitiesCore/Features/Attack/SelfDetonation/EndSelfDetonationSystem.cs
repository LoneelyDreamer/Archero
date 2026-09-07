using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.SelfDetonation
{
    public class EndSelfDetonationSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endSelfDetonationEvent;
        private ReactiveVeriable<bool> _inSelfDetonationProcess;
        private ReactiveVeriable<float> _selfDetonationProcessInitialTime;
        private ReactiveVeriable<float> _selfDetonationProcessCurrentTime;
        private ReactiveVeriable<bool> _isDead;


        private IDisposable _timerDisposable;

        public void OnInit(Entity entity)
        {
            _endSelfDetonationEvent = entity.EndSelfDetonationEvent;
            _inSelfDetonationProcess = entity.InSelfDetonationProcess;
            _selfDetonationProcessInitialTime = entity.SelfDetonationProcessInitialTime;
            _selfDetonationProcessCurrentTime = entity.SelfDetonationProcessCurrentTime;
            _isDead = entity.IsDead;

            _timerDisposable = _selfDetonationProcessCurrentTime.Subscribe(OnTimerChanged);
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (TimerIsDone(currentTime))
            {
                Debug.Log("finishSelfDetonation");
                _inSelfDetonationProcess.Value = false;
                _endSelfDetonationEvent.Invoke();
                _isDead.Value = true;
            }
        }

        private bool TimerIsDone(float currentTime) => currentTime >= _selfDetonationProcessInitialTime.Value;

        public void OnDispose()
        {
            _timerDisposable.Dispose();
        }
    }
}
