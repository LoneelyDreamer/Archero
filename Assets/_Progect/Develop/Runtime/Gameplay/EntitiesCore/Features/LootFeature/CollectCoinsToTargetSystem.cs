using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class CollectCoinsToTargetSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<Entity> _target;
        private ReactiveVeriable<int> _coins;
        private ReactiveVeriable<bool> _isCollected;

        private IDisposable _collectedChangedDisposable;
        
        public void OnInit(Entity entity)
        {
            _target = entity.CurrentTarget;
            _coins = entity.Coins;
            _isCollected = entity.IsCollected;

            _collectedChangedDisposable = _isCollected.Subscribe(OnIsCollectedChanged);
        }

        private void OnIsCollectedChanged(bool arg1, bool isCollected)
        {
            if (isCollected)
                _target.Value.Coins.Value += _coins.Value;
        }

        public void OnDispose()
        {
            _collectedChangedDisposable.Dispose();
        }

    }
}
