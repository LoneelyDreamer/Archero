using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack
{
    public class StartAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startAttackRequest;
        private ReactiveEvent _startAttackEvent;
        private ReactiveVeriable<bool> _inAttackProcess;
        private ICompositCondition _canStartAttack;

        private IDisposable _attackRequestDispose;

        public void OnInit(Entity entity)
        {
            _startAttackRequest = entity.StartAttackRequest;
            _startAttackEvent = entity.StartAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _canStartAttack = entity.CanStartAttack;

            _attackRequestDispose = _startAttackRequest.Subscribe(OnAttackRequest);
        }

        private void OnAttackRequest()
        {
            if(_canStartAttack.Evaluate())
            {
                _inAttackProcess.Value = true;
                _startAttackEvent.Invoke();
                Debug.Log("Start attack");
            }
            else
            {
                Debug.Log("can not attack");
            }
        }

        public void OnDispose()
        {
            _attackRequestDispose.Dispose();
        }
    }
}
