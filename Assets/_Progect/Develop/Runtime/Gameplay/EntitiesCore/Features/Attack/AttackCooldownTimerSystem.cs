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
    public class AttackCooldownTimerSystem : IInitializableSystem, IDisposable, IUpdatableSystem
    {
        private ReactiveVeriable<float> _currentTime;
        private ReactiveVeriable<float> _initialTime;
        private ReactiveVeriable<bool> _inAttackCooldown;

        private ReactiveEvent _endAttackEvent;

        private IDisposable _endAttackEventDisposable;

      
        public void OnInit(Entity entity)
        {
            _currentTime = entity.AttackCooldownCurrentTime;
            _initialTime = entity.AttackCooldownInitialTime;
            _inAttackCooldown = entity.InAttackCooldown;

            _endAttackEvent = entity.EndAttackEvent;
            _endAttackEventDisposable = _endAttackEvent.Subscribe(OnEndAttack);
        }
        private void OnEndAttack()
        {
            Debug.Log("Cooldown Started");
            _currentTime.Value = _initialTime.Value;
            _inAttackCooldown.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackCooldown.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if(CooldownIsOver())
            {
                _inAttackCooldown.Value = false;
                Debug.Log("Cooldown overed");
            }

        }

        private bool CooldownIsOver() => _currentTime.Value <= 0;

        public void Dispose()
        {
            _endAttackEventDisposable.Dispose();
        }

      
    }
}
