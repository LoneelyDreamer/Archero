using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.SelfDetonation
{
    public class ContactDetonationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ICompositCondition _mustDetonate;
        private ReactiveEvent _startSelfDetonationRequest;
        private ReactiveVeriable<bool> _isDetonatingOnInstall;

        public void OnInit(Entity entity)
        {
            _mustDetonate = entity.MustDetonate;
            _startSelfDetonationRequest = entity.StartSelfDetonationRequest;
            _isDetonatingOnInstall = entity.IsDetonatingOnInstall;                     
        }       

        public void OnUpdate(float deltaTime)
        {
            if (_isDetonatingOnInstall.Value)
            {
                _startSelfDetonationRequest.Invoke();
            }

            if (_mustDetonate.Evaluate())
            {
                Debug.Log("_mustDetonate");

                _startSelfDetonationRequest.Invoke();
            }
        }
    }
}
