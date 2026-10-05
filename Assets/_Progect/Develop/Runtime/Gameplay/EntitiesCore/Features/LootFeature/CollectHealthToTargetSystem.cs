using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class CollectHealthToTargetSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<Entity> _target;
        private ReactiveVeriable<float> _health;
        private ReactiveVeriable<bool> _isCollected;

        private IDisposable _collectedChangedDisposable;

        public void OnInit(Entity entity)
        {
            _target = entity.CurrentTarget;
            _health = entity.CurrentHealth;
            _isCollected = entity.IsCollected;

            _collectedChangedDisposable = _isCollected.Subscribe(OnIsCollectedChanged);
        }

        private void OnIsCollectedChanged(bool arg1, bool isCollected)
        {
            ReactiveVeriable<float> currentHealth = _target.Value.CurrentHealth;
            ReactiveVeriable<float> maxHealth = _target.Value.MaxHealth;

            if(currentHealth.Value + _health.Value > maxHealth.Value)
            {
                currentHealth.Value = maxHealth.Value;
                return;
            }

            currentHealth.Value += _health.Value;
        }

        public void OnDispose()
        {
            _collectedChangedDisposable.Dispose();
        }
    }
}
