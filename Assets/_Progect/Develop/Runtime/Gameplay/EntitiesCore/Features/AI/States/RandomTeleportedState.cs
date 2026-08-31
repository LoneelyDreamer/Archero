using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Teleport;
using Assets._Progect.Develop.Runtime.Utillitles.MathfOperations;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class RandomTeleportedState : State, IUpdatableState
    {
        private ReactiveEvent _startTeleportRequest;
        private ReactiveVeriable<bool> _inTeleportProcess;
        private ReactiveVeriable<Vector3> _teleportionTarget;
        private ReactiveVeriable<float> _teleportRadius;


        private Rigidbody _rigidbody;

        public RandomTeleportedState(Entity entity)
        {
            _startTeleportRequest = entity.StartTeleportRequest;
            _inTeleportProcess = entity.InTeleportProcess;
            _teleportionTarget = entity.TeleportionTarget;

            _teleportRadius = entity.TeleportRadius;
            _rigidbody = entity.Rigidbody;
        }

        public override void Enter()
        {
            base.Enter();

            GenerateRandomTeleportionPosition();

            _inTeleportProcess.Value = true;

            _startTeleportRequest.Invoke();

            Debug.Log("RandomTeleportedState - Enter ");
        }

        private void GenerateRandomTeleportionPosition()
        {
            Vector3 currentPos = _rigidbody.transform.position;
            Vector3 targetPos = MathfOpreartions.GenerateRandomTeleportionPosition(currentPos, _teleportRadius.Value);
            _teleportionTarget.Value = targetPos;
        }

        public override void Exit()
        {
            base.Exit();

            _inTeleportProcess.Value = false;

            Debug.Log("RandomTeleportedState - Exit ");
        }

        public void Update(float deltaTime)
        {

        }
    }
}
