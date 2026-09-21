using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Utillitles.Timer
{
    public class TimerService : IDisposable
    {
        private float _cooldown;

        private ReactiveEvent _cooldownEnded;

        private ReactiveVeriable<float> _currentTime;

        private ICoroutinesPerformer _coroutinePerformer;
        private Coroutine _cooldownProcess;

        public TimerService(float cooldown, ICoroutinesPerformer coroutinePerformer)
        {
            _cooldown = cooldown;
            _coroutinePerformer = coroutinePerformer;

            _cooldownEnded = new ReactiveEvent();
            _currentTime = new ReactiveVeriable<float>();
        }

        public IReadOnlyEvent CooldownEnded => _cooldownEnded;

        public IReadOnlyVeriable<float> CurrentTime => _currentTime;

        public bool IsOveer => _currentTime.Value <= 0;

        public void Dispose()
        {
            Stop();
        }

        private void Stop()
        {
            if (_cooldownProcess != null)
                _coroutinePerformer.StopPerform(_cooldownProcess);
        }

        public void Restart()
        {
            Stop();

            _cooldownProcess = _coroutinePerformer.StartPerform(CooldownProcess());
        }

        private IEnumerator CooldownProcess()
        {
            _currentTime.Value = _cooldown;

            while (IsOveer == false) 
            {
                _currentTime.Value -= Time.deltaTime;
                yield return null;
            }

            _cooldownEnded.Invoke();
        }
    }
}
