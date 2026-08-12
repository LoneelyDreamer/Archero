using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<bool> _isDead;
        //private ReactiveVeriable<float> _currentHealth;

        private ICompositCondition _mustDie;

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
           // _currentHealth = entity.CurrentHealth;
            _mustDie = entity.MustDie;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isDead.Value)
                return; 

            if(_mustDie.Evaluate())         
                _isDead.Value = true;
         
        }
    }
}
