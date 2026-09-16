using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature
{
    [RequireComponent(typeof(Animator))]
    public class SpawnProcessView : EntityView
    {
        private readonly int InSpawnProcessKey = Animator.StringToHash("InSpawnProcess");

        [SerializeField] private ParticleSystem _spawnEffectPrefab;
        [SerializeField] private Animator _animator;

        private ReactiveVeriable<bool> _inSpawnProcess;
        private Transform _entityTransform;

        private IDisposable _inSpawnProcessChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _inSpawnProcess = entity.InSpawnProcess;
            _entityTransform = entity.Transform;

            _inSpawnProcessChangedDisposable = _inSpawnProcess.Subscribe(OnSpawnProcessChanged);
        }               
 
        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _inSpawnProcessChangedDisposable.Dispose();
        }

        private void OnSpawnProcessChanged(bool arg1, bool newValue) => UpdateSpawnProcessKey(newValue);

        private void UpdateSpawnProcessKey(bool newValue)
        {
            _animator.SetBool(InSpawnProcessKey, newValue);

            if (newValue)
                Instantiate(_spawnEffectPrefab, _entityTransform.position, _spawnEffectPrefab.transform.rotation, null);
           
        }
    }
}
