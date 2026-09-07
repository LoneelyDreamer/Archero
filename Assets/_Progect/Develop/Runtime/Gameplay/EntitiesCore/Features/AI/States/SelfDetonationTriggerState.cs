using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class SelfDetonationTriggerState : State, IUpdatableState
    {
        private ReactiveEvent _selfDetonatioRequest;
        private ReactiveVeriable<Vector3> _movementDirection;
      
        public SelfDetonationTriggerState(Entity entity)
        {
            _selfDetonatioRequest = entity.StartSelfDetonationRequest;
            _movementDirection = entity.MoveDirection;
        }

        public override void Enter()
        {
            base.Enter();

            _selfDetonatioRequest.Invoke();

            _movementDirection.Value = Vector3.zero;
        }

        public void Update(float deltaTime)
        {
        }
    }
}
