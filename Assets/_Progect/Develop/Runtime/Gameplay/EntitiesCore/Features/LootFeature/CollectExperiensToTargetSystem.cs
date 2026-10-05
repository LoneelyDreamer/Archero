using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class CollectExperiensToTargetSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<Entity> _target;
        private ReactiveVeriable<float> _experience;
        private ReactiveVeriable<bool> _isCollected;

        private IDisposable _collectedChangedDisposable;

        public void OnInit(Entity entity)
        {
            _target = entity.CurrentTarget;
            _experience = entity.Experience;
            _isCollected = entity.IsCollected;

            _collectedChangedDisposable = _isCollected.Subscribe(OnIsCollectedChanged);
        }

        private void OnIsCollectedChanged(bool arg1, bool isCollected)
        {
            if (isCollected)
                _target.Value.Experience.Value += _experience.Value;
        }

        public void OnDispose()
        {
            _collectedChangedDisposable.Dispose();
        }
    }
}
