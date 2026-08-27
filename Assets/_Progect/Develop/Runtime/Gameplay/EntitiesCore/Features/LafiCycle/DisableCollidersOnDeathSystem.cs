using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class DisableCollidersOnDeathSystem : IInitializableSystem, IDisposableSystem
    {
        private List<Collider> _colliders;
        private ReactiveVeriable<bool> _isDead;

        private IDisposable _isDeadChangedDisposable;

        public void OnInit(EntityLifeContext entity)
        {
            _colliders = entity.DisableCollidersOnDeath;
            _isDead = entity.IsDead;

            _isDeadChangedDisposable = _isDead.Subscribe(OnIsDeadChanged);
        }

        private void OnIsDeadChanged(bool arg1, bool isDead)
        {
            if(isDead)
            {
                foreach (Collider collider in _colliders)
                    collider.enabled = false;
            }
               
        }

        public void OnDispose()
        {
            _isDeadChangedDisposable.Dispose();
        }
    }
}
