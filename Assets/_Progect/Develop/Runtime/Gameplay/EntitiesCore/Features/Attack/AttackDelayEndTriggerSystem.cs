using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack
{
    public class AttackDelayEndTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _attackDelayEndEvent;
        private ReactiveVeriable<float> _delay;
        private ReactiveVeriable<float> _attackProcessCurrentTime;

        private ReactiveEvent _startAttackEvent;

        private bool _alreadyAttacked;

        private IDisposable _timerDisposable;      
        private IDisposable _startAttackDisposable;      

        public void OnInit(EntityLifeContext entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _delay = entity.AttackDelayTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;
            _startAttackEvent = entity.StartAttackEvent;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
            _startAttackDisposable = _startAttackEvent.Subscribe(OnStartAttack);
        }

        private void OnStartAttack()
        {
            _alreadyAttacked = false;
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
            _startAttackDisposable.Dispose();
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (_alreadyAttacked)
                return;

            if (currentTime >= _delay.Value)
            {
                Debug.Log("Delay befor attack ended");
                _attackDelayEndEvent.Invoke();
                _alreadyAttacked = true;
            }
        }
    }
}
