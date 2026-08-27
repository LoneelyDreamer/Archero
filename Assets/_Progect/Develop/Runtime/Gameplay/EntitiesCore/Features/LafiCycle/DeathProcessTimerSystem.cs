using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class DeathProcessTimerSystem : IInitializableSystem, IDisposableSystem, IUpdatableSystem
    {
        private ReactiveVeriable<bool> _isDead;
        private ReactiveVeriable<bool> _inDeathProcess;
        private ReactiveVeriable<float> _initialTime;
        private ReactiveVeriable<float> _currentTime;

        private IDisposable _isDeadChangedDisposeble;

        public void OnInit(EntityLifeContext entity)
        {
            _isDead = entity.IsDead;
            _inDeathProcess = entity.InDeadProcess;
            _initialTime = entity.DeathProcessInitialTime;
            _currentTime = entity.DeathProcessCurrentTime;

            _isDeadChangedDisposeble = _isDead.Subscribe(OnIsDeadChanged);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inDeathProcess.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (CooldownIsOver())
                _inDeathProcess.Value = false;
        }

        public void OnDispose()
        {
            _isDeadChangedDisposeble.Dispose();
        }

        private void OnIsDeadChanged(bool arg1, bool isDead)
        {
            if (isDead)
            {
                _currentTime.Value = _initialTime.Value;
                _inDeathProcess.Value = true;
            }
        }

        private bool CooldownIsOver() => _currentTime.Value <= 0;
    }
}
