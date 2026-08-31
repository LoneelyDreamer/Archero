using Assets._Progect.Develop.Runtime.Utillitles.MathfOperations;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class TeleportToTargetState : State, IUpdatableState
    {
        private ReactiveEvent _startTeleportRequest;
        private ReactiveVeriable<bool> _inTeleportProcess;
        private ReactiveVeriable<Vector3> _teleportionTarget;
        private ReactiveVeriable<Entity> _currentTarget;

        public TeleportToTargetState(Entity entity)
        {
            _startTeleportRequest = entity.StartTeleportRequest;
            _inTeleportProcess = entity.InTeleportProcess;
            _teleportionTarget = entity.TeleportionTarget;
            _currentTarget = entity.CurrentTarget;
        }

        public override void Enter()
        {
            base.Enter();

            SetTeleportationPosition();

            _inTeleportProcess.Value = true;

            if (_currentTarget.Value != null)
                _startTeleportRequest.Invoke();
            else
                Exit();

            Debug.Log("TeleportToTargetState - Enter ");
        }

        private void SetTeleportationPosition()
        {
            if (_currentTarget.Value != null)
                _teleportionTarget.Value = _currentTarget.Value.Transform.position;
        }

        public override void Exit()
        {
            base.Exit();

            _inTeleportProcess.Value = false;

            Debug.Log("TeleportToTargetState - Exit ");
        }

        public void Update(float deltaTime)
        {

        }
    }
}
