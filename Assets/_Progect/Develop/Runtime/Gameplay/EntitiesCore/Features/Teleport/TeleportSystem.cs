using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Energy;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.MathfOperations;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Teleport
{
    public class TeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<float> _teleportSkillPrice;
        private ReactiveVeriable<float> _currentEnergy;
        private ReactiveVeriable<bool> _inTeleportProcess;
        private ReactiveVeriable<Vector3> _teleportionTarget;

        private ReactiveEvent _startTeleportRequest;
        private ReactiveEvent _startTeleportEvent;

        private Rigidbody _rigidbody;

        private ICompositCondition _canUseTeleportSkill;

        private IDisposable _teleportRequestDispose;

        public void OnInit(Entity entity)
        {
            _inTeleportProcess = entity.InTeleportProcess;
            _teleportSkillPrice = entity.TeleportSkillPrice;
            _currentEnergy = entity.CurrentEnergy;
            _teleportionTarget = entity.TeleportionTarget;

            _canUseTeleportSkill = entity.CanUseTeleportSkill;

            _rigidbody = entity.Rigidbody;

            _startTeleportRequest = entity.StartTeleportRequest;
            _startTeleportEvent = entity.StartTeleportEvent;

            _teleportRequestDispose = _startTeleportRequest.Subscribe(OnTeleportStarted);
        }

        private void OnTeleportStarted()
        {           

            if (!_canUseTeleportSkill.Evaluate())
            {
                _inTeleportProcess.Value = false;
                Debug.Log("Teleport skill not available, resetting flag");
                return;
            }

            _startTeleportEvent.Invoke();
            _currentEnergy.Value -= _teleportSkillPrice.Value;

            Vector3 targetPos = _teleportionTarget.Value;

            _rigidbody.transform.position = targetPos;
            _inTeleportProcess.Value = false;
            Debug.Log($"Teleported to {targetPos}");
        }       

        public void OnDispose()
        {
            _teleportRequestDispose.Dispose();
        }
    }
}
