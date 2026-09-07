using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.SelfDetonation
{
    public class StartSelfDetonationSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startSelfDetonationRequest;
        private ReactiveEvent _startSelfDetonationEvent;
        private ReactiveVeriable<bool> _inSelfDetonationProcess;
        private ICompositCondition _canStartSelfDetonation;

        private IDisposable _selfDetonationRequestDispose;


        public void OnInit(Entity entity)
        {
            _startSelfDetonationRequest = entity.StartSelfDetonationRequest;
            _startSelfDetonationEvent = entity.StartSelfDetonationEvent;
            _inSelfDetonationProcess = entity.InSelfDetonationProcess;
            _canStartSelfDetonation = entity.CanStartSelfDetonation;

            _selfDetonationRequestDispose = _startSelfDetonationRequest.Subscribe(OnSelfDetonationRequest);
        }

        private void OnSelfDetonationRequest()
        {
            if (_canStartSelfDetonation.Evaluate())
            {
                _inSelfDetonationProcess.Value = true;
                _startSelfDetonationEvent.Invoke();
                Debug.Log("SelfDetonation");
            }
            else
            {
                Debug.Log("can not SelfDetonation");
            }
        }        

        public void OnDispose()
        {
            _selfDetonationRequestDispose.Dispose();
        }
    }
}
