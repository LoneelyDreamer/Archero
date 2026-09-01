using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class PlayerInputRotationState : State, IUpdatableState
    {
        private IInputService _inputService;
        private ReactiveVeriable<Vector3> _rotationDirection;
        private Transform _transform;

        private readonly Camera _camera;
        private readonly float _targetHeight;

        public PlayerInputRotationState(IInputService inputService, Entity entity)
        {
            _inputService = inputService;
            _rotationDirection = entity.RotationDirection;
            _transform = entity.Transform;
            _camera = Camera.main;
            _targetHeight = _transform.position.y;
        }

        public void Update(float deltaTime)
        {
            Vector3 mouseScreenPos = _inputService.MousePosition;

            Ray ray = _camera.ScreenPointToRay(mouseScreenPos);

            Plane groundPlane = new Plane(Vector3.up, new Vector3(0, _targetHeight, 0));

            float distance;

            if (groundPlane.Raycast(ray, out distance))
            {
                Vector3 targetPoint = ray.GetPoint(distance);

                Vector3 direction = targetPoint - _transform.position;

                direction.y = 0f;

                if (direction.sqrMagnitude > 0.0001f)  
                {
                    _rotationDirection.Value = direction.normalized;
                }
            }
        }
    }
}
