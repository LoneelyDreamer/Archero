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
    [RequireComponent(typeof(Animator))]
    public class InstantAttackView : EntityView
    {
        private readonly int IsAttackKey = Animator.StringToHash("IsAttack");

        [SerializeField] private Animator _animator;

        private IReadOnlyVeriable<bool> _inAttackProcess;

        private IDisposable _inAttackProcessChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _inAttackProcess = entity.InAttackProcess;

            _inAttackProcessChangedDisposable = _inAttackProcess.Subscribe(OnIsDeadChanged);
            UpdateIsDead(_inAttackProcess.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _inAttackProcessChangedDisposable.Dispose();
        }

        private void OnIsDeadChanged(bool oldInAttackProcess, bool inAttackProcess) => UpdateIsDead(inAttackProcess);

        private void UpdateIsDead(bool value) => _animator.SetBool(IsAttackKey, value);
    }
}
