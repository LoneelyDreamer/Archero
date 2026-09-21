using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack
{
    public class CurrentTargetView : EntityView
    {
        [SerializeField] private ParticleSystem _backLightPrefab;

        private ParticleSystem _backlight;

        private ReactiveVeriable<Entity> _currentTarget;
        private Transform _currentTargetTransform;

        private IDisposable _currentTargetChangedDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _currentTarget = entity.CurrentTarget;

            _backlight = Instantiate(_backLightPrefab);

            _currentTargetChangedDisposable = _currentTarget.Subscribe(OnCurrentTargetChanged);

            UpdateBackLightFor(_currentTarget.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _currentTargetChangedDisposable.Dispose();
            Destroy(_backlight.gameObject);
        }

        private void OnCurrentTargetChanged(Entity entity1, Entity newTarget)
        {
            UpdateBackLightFor(newTarget);
        }

        private void UpdateBackLightFor(Entity newTarget)
        {
            if (newTarget == null)
            {
                _backlight.gameObject.SetActive(false);
                _currentTargetTransform = null; 
                return;
            }

            _backlight.gameObject.SetActive(true);
            _currentTargetTransform = newTarget.Transform;
        }           

        private void LateUpdate()
        {
            if (_currentTargetTransform == null)
                return;

            _backlight.transform.position = _currentTargetTransform.position;
        }

       
    }
}
