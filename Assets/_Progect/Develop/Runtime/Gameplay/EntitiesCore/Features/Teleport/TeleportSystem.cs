using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Energy;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
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
        private ReactiveVeriable<float> _teleportRadius;
        private ReactiveVeriable<float> _teleportSkillPrice;
        private ReactiveVeriable<float> _currentEnergy;

        private ReactiveEvent _startTeleportRequest;
        private ReactiveEvent _startTeleportEvent;

        private Rigidbody _rigidbody;

        private ICompositCondition _canUseTeleportSkill;

        private IDisposable _teleportRequestDispose;     

        public void OnInit(Entity entity)
        {
            _teleportRadius = entity.TeleportRadius;
            _teleportSkillPrice = entity.TeleportSkillPrice;
            _currentEnergy = entity.CurrentEnergy;

            _canUseTeleportSkill = entity.CanUseTeleportSkill;

            _rigidbody = entity.Rigidbody;

            _startTeleportRequest = entity.StartTeleportRequest;
            _startTeleportEvent = entity.StartTeleportEvent;

            _teleportRequestDispose = _startTeleportRequest.Subscribe(OnTeleportStarted);
        }

        private void OnTeleportStarted()
        {
            if(_canUseTeleportSkill.Evaluate() == false)
                return;

            _startTeleportEvent.Invoke();

            _currentEnergy.Value -= _teleportSkillPrice.Value;

            Vector3 currentPositiopn = _rigidbody.transform.position;
            float newX = Random.Range(-_teleportRadius.Value, _teleportRadius.Value);
            float newZ = Random.Range(-_teleportRadius.Value, _teleportRadius.Value);
            Vector3 teleportationPosition = new Vector3(currentPositiopn.x + newX, currentPositiopn.y, currentPositiopn.z + newZ);

            _rigidbody.transform.position = teleportationPosition;

            Debug.Log("teleportationPosition = " + teleportationPosition.ToString());
        }

        public void OnDispose()
        {
            _teleportRequestDispose.Dispose();
        }
    }
}
