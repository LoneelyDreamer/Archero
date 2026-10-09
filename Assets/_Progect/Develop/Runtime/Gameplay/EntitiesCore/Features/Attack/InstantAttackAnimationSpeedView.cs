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
    public class InstantAttackAnimationSpeedView : EntityView
    {
        private readonly int _attackAnimationSpeedMultiplierKey = Animator.StringToHash("AttackAnimationSpeedMultiplier");

        [SerializeField] private AnimationClip _animationClip;
        [SerializeField] private Animator _animator;

        private ReactiveVeriable<float> _attackProcessInitialTime;
        private ReactiveVeriable<float> _attackProssecModifiedTime;

        private IDisposable _attackProcessTimeChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }
        protected override void OnEntityStartedWork(Entity entity)
        {
            _attackProcessInitialTime = entity.AttackProcessInitialTime;
            _attackProssecModifiedTime = entity.AttackProcessModifiedTime;

            _attackProcessTimeChangedDisposable = _attackProssecModifiedTime.Subscribe(OnAttackProcessTimeChnged);
            OnAttackProcessTimeChnged(0, _attackProssecModifiedTime.Value);
            //_animator.SetFloat(_attackAnimationSpeedMultiplierKey, _animationClip.length / _attackProcessInitialTime.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _attackProcessTimeChangedDisposable.Dispose();
        }

        private void OnAttackProcessTimeChnged(float arg1, float currentAttackProcessTime)
        {
            _animator.SetFloat(_attackAnimationSpeedMultiplierKey, _attackProcessInitialTime.Value / currentAttackProcessTime);
        }
    }
}
