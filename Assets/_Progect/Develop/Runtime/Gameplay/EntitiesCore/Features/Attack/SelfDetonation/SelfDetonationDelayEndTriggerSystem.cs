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
    public class SelfDetonationDelayEndTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _selfDetonationDelayEndEvent;
        private ReactiveVeriable<float> _delay;
        private ReactiveVeriable<float> _selfDetonationProcessCurrentTime;

        private ReactiveEvent _startSelfDetonationEvent;

        private bool _alreadyDetonated;

        private IDisposable _timerDisposable;
        private IDisposable _startSelfDetonationDisposable;

        public void OnInit(Entity entity)
        {
            _selfDetonationDelayEndEvent = entity.SelfDetonationDelayEndEvent;
            _delay = entity.SelfDetonationProcessInitialTime;
            _selfDetonationProcessCurrentTime = entity.SelfDetonationProcessCurrentTime;
            _startSelfDetonationEvent = entity.StartSelfDetonationEvent;

            _timerDisposable = _selfDetonationProcessCurrentTime.Subscribe(OnTimerChanged);
            _startSelfDetonationDisposable = _startSelfDetonationEvent.Subscribe(OnDetonate);
        }

        private void OnDetonate()
        {
            _alreadyDetonated = false;
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
            _startSelfDetonationDisposable.Dispose();
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (_alreadyDetonated)
                return;

            if (currentTime >= _delay.Value)
            {
                Debug.Log("Delay befor Detonate ended");
                _selfDetonationDelayEndEvent.Invoke();
                _alreadyDetonated = true;
            }
        }
    }
}
