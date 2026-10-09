using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public class AttackTimeByAttackSpeedStatsSynchronizerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<float> _attackPerSecond;

        private ReactiveVeriable<float> _attackProcessInitialTime;
        private ReactiveVeriable<float> _attackProcessModifiedTime;
        private ReactiveVeriable<float> _attackCooldowInitialTime;
        private ReactiveVeriable<float> _attackCooldowModifiedTime;
        private ReactiveVeriable<float> _attackDeleyInitialTime;
        private ReactiveVeriable<float> _attackDeleyModifiedTime;

        private IDisposable _attackPerSecondChangedDisposable;
        public void OnDispose()
        {
            _attackPerSecondChangedDisposable.Dispose();
        }

        public void OnInit(Entity entity)
        {
            _attackPerSecond = entity.AttackPerSecond;

            _attackProcessInitialTime = entity.AttackProcessInitialTime;
            _attackProcessModifiedTime = entity.AttackProcessModifiedTime;
            _attackCooldowInitialTime = entity.AttackCooldownInitialTime;
            _attackCooldowModifiedTime = entity.AttackCooldownModifiedTime;
            _attackDeleyInitialTime = entity.AttackDelayTime;
            _attackDeleyModifiedTime = entity.AttackDelayModifiedTime;

            _attackPerSecondChangedDisposable = _attackPerSecond.Subscribe(OnAttackPerSecondChanged);
            OnAttackPerSecondChanged(0, _attackPerSecond.Value);
        }

        private void OnAttackPerSecondChanged(float arg1, float newAttackPerSecond)
        {
            float totalBaseTime = _attackProcessInitialTime.Value + _attackCooldowInitialTime.Value;

            float targetTotalTime = 1f / newAttackPerSecond;

            float totalTimeRatio = targetTotalTime / totalBaseTime;

            _attackProcessModifiedTime.Value = _attackProcessInitialTime.Value * totalTimeRatio;
            _attackCooldowModifiedTime.Value = _attackCooldowInitialTime.Value * totalTimeRatio;
            _attackDeleyModifiedTime.Value = _attackDeleyInitialTime.Value * totalTimeRatio;
        }
    }
}
