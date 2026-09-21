using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack
{
    public class EndAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endAttackEvent;
        private ReactiveVeriable<bool> _inAttackProcess;
        private ReactiveVeriable<float> _attackProcessInitialTime;
        private ReactiveVeriable<float> _attackProcessCurrentTime;

        private IDisposable _timerDisposable;

       

        public void OnInit(Entity entity)
        {
            _endAttackEvent = entity.EndAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _attackProcessInitialTime = entity.AttackProcessInitialTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if(TimerIsDone(currentTime))
            {
                Debug.Log("finishAttack");
                _inAttackProcess.Value = false;
                _endAttackEvent.Invoke();
            }
        }

        private bool TimerIsDone(float currentTime) => currentTime >= _attackProcessInitialTime.Value;

        public void OnDispose()
        {
            _timerDisposable.Dispose();
        }
    }
}
