using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class RandomMovmentState : State
    {
        private ReactiveVeriable<Vector3> _movementDirection;
        private ReactiveVeriable<Vector3> _rotationDirection;

        private float _cooldownBetweenDirectionGeneration;

        private float _time;

        public RandomMovmentState(
            Entity entity, 
            float cooldownBetweenDirectionGeneration)
        {
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

            _cooldownBetweenDirectionGeneration = cooldownBetweenDirectionGeneration;
        }

        public override void Enter()
        {
            base.Enter();

            Vector3 randomDiraction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            _movementDirection.Value = randomDiraction;
            _rotationDirection.Value = randomDiraction;

            _time = 0;
        }

        public override void Exit()
        {
            base.Exit();

            _movementDirection.Value = Vector3.zero;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if(_time > _cooldownBetweenDirectionGeneration)
            {
                GenerateNewDiraction();
                _time = 0;
            }
        }

        private void GenerateNewDiraction()
        {
            Vector3 inversDirection = -_movementDirection.Value.normalized;
            Quaternion randomTern = Quaternion.Euler(0, Random.Range(-30, 30), 0);
            Vector3 newDiraction = randomTern * inversDirection;

            _movementDirection.Value = newDiraction;
            _rotationDirection.Value = newDiraction;
        }
    }
}
