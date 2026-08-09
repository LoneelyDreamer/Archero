using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        public ReactiveVeriable<bool> _isDead;
        public ReactiveVeriable<float> _currentHealth;

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _currentHealth = entity.CurrentHealth;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isDead.Value)
                return; 

            if(_currentHealth.Value <= 0)
            {
                _isDead.Value = true;
                Debug.Log("I died");
            }
        }
    }
}
