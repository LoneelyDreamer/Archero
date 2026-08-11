using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack
{
    public class AttackCanselSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<bool> _inAttackProcess;
        private ReactiveEvent _attcakCanseledEvent;

        private ICompositCondition _mustCanselAttack;

        public void OnInit(Entity entity)
        {
            _inAttackProcess = entity.InAttackProcess;
            _attcakCanseledEvent = entity.AttackCanseledEvent;

            _mustCanselAttack = entity.MustCanselAttack;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;
            
            if (_mustCanselAttack.Evaluate())
            {
                Debug.Log(" process Attack Canseled");
                _inAttackProcess.Value = false;
                _attcakCanseledEvent.Invoke();
            }
        }
    }
}
